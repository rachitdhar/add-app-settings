Imports System.IO
Imports System.Text
Imports System.Text.Json
Imports System.Text.Json.Nodes
Imports System.Text.RegularExpressions

Public Class WinApp
    Dim DefaultMainPath As String
    Dim AppRoot As String
    Dim paths As JsonObject
    Dim ProjectsWithAdditionalSettings As List(Of String)

    Private Sub AddButton_Click(sender As Object, e As EventArgs) Handles AddButton.Click
        Dim projectSelected As String = ProjectDropdown.Text
        Dim envSelected As String = EnvDropdown.Text
        Dim location As String = MainLocationTextBox.Text.Trim()

        If (location.ElementAt(location.Length - 1) = "\" Or location.ElementAt(location.Length - 1) = "/") Then
            location = location.Remove(location.Length - 1)
        End If
        location += paths(projectSelected).ToString()

        Dim appSettingsLocation As String = location + "appsettings.json"
        Dim localLocation As String = location + "local.settings.json"
        Dim hostLocation As String = location + "host.json"
        Dim envSettingsLocation = AppRoot + "\appsettings\" + envSelected + ".json"
        Dim envSettings As JsonObject = JsonObject.Parse(File.ReadAllText(envSettingsLocation))

        Try
            'Add Appsettings
            Dim jsonData As String = File.ReadAllText(appSettingsLocation)
            Dim jObject As JsonObject = JsonObject.Parse(jsonData)

            If (jObject("ConnectionString") IsNot Nothing) And (jObject("Serilog") IsNot Nothing) Then
                jObject("ConnectionString") = envSettings("ConnectionString").DeepClone()

                Dim SerilogJObj As JsonObject = CType(jObject("Serilog"), JsonObject)
                If SerilogJObj("WriteTo") IsNot Nothing Then
                    SerilogJObj("WriteTo") = envSettings("WriteTo").DeepClone()
                End If
            Else
                Throw New Exception()
            End If

            Dim options As New JsonSerializerOptions With {
                .Encoder = Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
                .WriteIndented = True
            }
            Dim jsonString As String = JsonSerializer.Serialize(jObject, options)
            File.WriteAllText(appSettingsLocation, jsonString, Encoding.UTF8)

            If (ProjectsWithAdditionalSettings.Contains(projectSelected)) Then
                'Add Local Settings
                If (CheckBoxLocalSettings.Checked) Then
                    Dim localJObject As JsonObject = JsonObject.Parse(File.ReadAllText(localLocation))

                    If (localJObject("Values") IsNot Nothing) Then
                        Dim ValuesJObj As JsonObject = CType(localJObject("Values"), JsonObject)
                        If ValuesJObj("ServiceBusConnection") IsNot Nothing Then
                            Dim ConnectionStringJObj As JsonObject = CType(envSettings("ConnectionString"), JsonObject)
                            ValuesJObj("ServiceBusConnection") = ConnectionStringJObj("ServiceBusConnection").DeepClone()
                        End If
                    End If

                    Dim localJsonString As String = JsonSerializer.Serialize(localJObject, options)
                    File.WriteAllText(localLocation, localJsonString, Encoding.UTF8)
                End If

                'Add Host Function
                If (FunctionsComboBox.Text IsNot "") And (FunctionsComboBox.Text IsNot "Select Function") Then
                    Dim hostJsonContent As String = File.ReadAllText(hostLocation)
                    Dim commentedPattern As String = "//\s*,\s*""functions""\s*:\s*\[.*?\]"

                    ' Remove the comment on functions if it exists
                    If Regex.IsMatch(hostJsonContent, commentedPattern) Then
                        hostJsonContent = Regex.Replace(hostJsonContent, commentedPattern, ",""functions"": []")
                    End If

                    Dim hostJObject As JsonObject = JsonObject.Parse(hostJsonContent)
                    hostJObject("functions") = New JsonArray(FunctionsComboBox.Text)

                    Dim hostJsonString As String = JsonSerializer.Serialize(hostJObject, options)
                    File.WriteAllText(hostLocation, hostJsonString, Encoding.UTF8)
                End If
            End If
            MsgBox("Success")
        Catch ex As Exception
            MsgBox("Failed to set appsettings")
        End Try
    End Sub

    Private Sub WinApp_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        BottomPanel.Top = EnvDropdown.Bottom + 10
        Me.Height = BottomPanel.Bottom + 50
        AppRoot = GetParentDirectory(AppDomain.CurrentDomain.BaseDirectory, 4)
        Dim pathsFileLocation As String = AppRoot + "\paths.json"
        paths = JsonObject.Parse(File.ReadAllText(pathsFileLocation))
        DefaultMainPath = paths("DefaultMainPath").ToString()
        ProjectsWithAdditionalSettings = Newtonsoft.Json.JsonConvert.DeserializeObject(Of List(Of String))(JsonSerializer.Serialize(paths("ProjectsWithAdditionalSettings")))

        ProjectDropdown.SelectedIndex = 0
        EnvDropdown.SelectedIndex = 0
        MainLocationTextBox.Text = DefaultMainPath
        MainPathLabel.Text = "Location of " + DefaultMainPath.Split("\")(1)
    End Sub

    Private Function GetParentDirectory(path As String, levelsUp As Integer) As String
        Dim currentPath As String = path
        For i As Integer = 1 To levelsUp
            currentPath = Directory.GetParent(currentPath).FullName
        Next
        Return currentPath
    End Function

    Private Sub BrowseButton_Click(sender As Object, e As EventArgs) Handles BrowseButton.Click
        If (FolderBrowserDialog1.ShowDialog = DialogResult.OK) Then
            MainLocationTextBox.Text = FolderBrowserDialog1.SelectedPath
        End If
    End Sub

    Private Sub ProjectDropdown_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ProjectDropdown.SelectedIndexChanged
        If (ProjectsWithAdditionalSettings.Contains(ProjectDropdown.Text)) Then
            AdditionalSettingsGroupBox.Visible = True
            BottomPanel.Top = AdditionalSettingsGroupBox.Bottom + 10
            Me.Height = BottomPanel.Bottom + 50
        Else
            AdditionalSettingsGroupBox.Visible = False
            CheckBoxLocalSettings.Checked = False
            BottomPanel.Top = EnvDropdown.Bottom + 10
            Me.Height = BottomPanel.Bottom + 50
        End If
    End Sub

    Private Sub LoadFunctionsList()
        Dim pattern As String = "\[Function\(nameof\((?<name>[a-zA-Z_][a-zA-Z0-9_]*)\)\)\]"
        Dim matchesList As New List(Of String)
        Dim allFiles = Directory.GetFiles(DefaultMainPath, "*.cs", SearchOption.AllDirectories)

        ' Process each file
        For Each f In allFiles
            Dim content As String = File.ReadAllText(f)
            Dim matches = Regex.Matches(content, pattern)

            For Each match As Match In matches
                matchesList.Add(match.Groups("name").Value)
            Next
        Next
        FunctionsComboBox.Items.Clear()
        FunctionsComboBox.Items.AddRange(matchesList.ToArray)
        FunctionsComboBox.Sorted = True
    End Sub

    Private Sub LoadFunctionsButton_Click(sender As Object, e As EventArgs) Handles LoadFunctionsButton.Click
        FunctionsComboBox.Enabled = False
        FunctionsComboBox.Text = "Loading..."
        Try
            LoadFunctionsList()
            FunctionsComboBox.Text = "Select Function"
            FunctionsComboBox.Enabled = True
        Catch ex As Exception
            FunctionsComboBox.Items.Clear()
            FunctionsComboBox.Text = ""
            MsgBox("Failed to load the functions")
        End Try
    End Sub
End Class
