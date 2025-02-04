<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class WinApp
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Label1 = New Label()
        AddButton = New Button()
        ProjectDropdown = New ComboBox()
        Label2 = New Label()
        EnvDropdown = New ComboBox()
        MainPathLabel = New Label()
        MainLocationTextBox = New TextBox()
        FolderBrowserDialog1 = New FolderBrowserDialog()
        BrowseButton = New Button()
        AdditionalSettingsGroupBox = New GroupBox()
        LoadFunctionsButton = New Button()
        FunctionsComboBox = New ComboBox()
        Label3 = New Label()
        CheckBoxLocalSettings = New CheckBox()
        BottomPanel = New Panel()
        AdditionalSettingsGroupBox.SuspendLayout()
        BottomPanel.SuspendLayout()
        SuspendLayout()
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(31, 23)
        Label1.Name = "Label1"
        Label1.Size = New Size(44, 15)
        Label1.TabIndex = 0
        Label1.Text = "Project"
        ' 
        ' AddButton
        ' 
        AddButton.Location = New Point(97, 62)
        AddButton.Name = "AddButton"
        AddButton.Size = New Size(80, 23)
        AddButton.TabIndex = 2
        AddButton.Text = "Add"
        AddButton.UseVisualStyleBackColor = True
        ' 
        ' ProjectDropdown
        ' 
        ProjectDropdown.FormattingEnabled = True
        ProjectDropdown.Items.AddRange(New Object() {"ExampleProj"})
        ProjectDropdown.Location = New Point(164, 20)
        ProjectDropdown.Name = "ProjectDropdown"
        ProjectDropdown.Size = New Size(137, 23)
        ProjectDropdown.TabIndex = 3
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Location = New Point(31, 51)
        Label2.Name = "Label2"
        Label2.Size = New Size(75, 15)
        Label2.TabIndex = 4
        Label2.Text = "Environment"
        ' 
        ' EnvDropdown
        ' 
        EnvDropdown.FormattingEnabled = True
        EnvDropdown.Items.AddRange(New Object() {"ExampleEnv"})
        EnvDropdown.Location = New Point(164, 48)
        EnvDropdown.Name = "EnvDropdown"
        EnvDropdown.Size = New Size(137, 23)
        EnvDropdown.TabIndex = 5
        ' 
        ' MainPathLabel
        ' 
        MainPathLabel.AutoSize = True
        MainPathLabel.Location = New Point(0, 9)
        MainPathLabel.Name = "MainPathLabel"
        MainPathLabel.Size = New Size(70, 15)
        MainPathLabel.TabIndex = 6
        MainPathLabel.Text = "Location of "
        ' 
        ' MainLocationTextBox
        ' 
        MainLocationTextBox.Location = New Point(0, 27)
        MainLocationTextBox.Name = "MainLocationTextBox"
        MainLocationTextBox.Size = New Size(197, 23)
        MainLocationTextBox.TabIndex = 7
        ' 
        ' BrowseButton
        ' 
        BrowseButton.Location = New Point(203, 27)
        BrowseButton.Name = "BrowseButton"
        BrowseButton.Size = New Size(70, 23)
        BrowseButton.TabIndex = 8
        BrowseButton.Text = "Browse"
        BrowseButton.UseVisualStyleBackColor = True
        ' 
        ' AdditionalSettingsGroupBox
        ' 
        AdditionalSettingsGroupBox.Controls.Add(LoadFunctionsButton)
        AdditionalSettingsGroupBox.Controls.Add(FunctionsComboBox)
        AdditionalSettingsGroupBox.Controls.Add(Label3)
        AdditionalSettingsGroupBox.Controls.Add(CheckBoxLocalSettings)
        AdditionalSettingsGroupBox.Location = New Point(31, 87)
        AdditionalSettingsGroupBox.Name = "AdditionalSettingsGroupBox"
        AdditionalSettingsGroupBox.Size = New Size(273, 128)
        AdditionalSettingsGroupBox.TabIndex = 9
        AdditionalSettingsGroupBox.TabStop = False
        AdditionalSettingsGroupBox.Text = "Additional Settings"
        AdditionalSettingsGroupBox.Visible = False
        ' 
        ' LoadFunctionsButton
        ' 
        LoadFunctionsButton.Location = New Point(203, 82)
        LoadFunctionsButton.Name = "LoadFunctionsButton"
        LoadFunctionsButton.Size = New Size(53, 23)
        LoadFunctionsButton.TabIndex = 3
        LoadFunctionsButton.Text = "Load"
        LoadFunctionsButton.UseVisualStyleBackColor = True
        ' 
        ' FunctionsComboBox
        ' 
        FunctionsComboBox.Enabled = False
        FunctionsComboBox.FormattingEnabled = True
        FunctionsComboBox.Location = New Point(18, 82)
        FunctionsComboBox.Name = "FunctionsComboBox"
        FunctionsComboBox.Size = New Size(179, 23)
        FunctionsComboBox.TabIndex = 2
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Location = New Point(16, 64)
        Label3.Name = "Label3"
        Label3.Size = New Size(123, 15)
        Label3.TabIndex = 1
        Label3.Text = "Function for host.json"
        ' 
        ' CheckBoxLocalSettings
        ' 
        CheckBoxLocalSettings.AutoSize = True
        CheckBoxLocalSettings.Location = New Point(18, 30)
        CheckBoxLocalSettings.Name = "CheckBoxLocalSettings"
        CheckBoxLocalSettings.Size = New Size(139, 19)
        CheckBoxLocalSettings.TabIndex = 0
        CheckBoxLocalSettings.Text = "Set local.settings.json"
        CheckBoxLocalSettings.UseVisualStyleBackColor = True
        ' 
        ' BottomPanel
        ' 
        BottomPanel.Controls.Add(MainLocationTextBox)
        BottomPanel.Controls.Add(MainPathLabel)
        BottomPanel.Controls.Add(BrowseButton)
        BottomPanel.Controls.Add(AddButton)
        BottomPanel.Location = New Point(31, 221)
        BottomPanel.Name = "BottomPanel"
        BottomPanel.Size = New Size(273, 85)
        BottomPanel.TabIndex = 10
        ' 
        ' WinApp
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(335, 319)
        Controls.Add(BottomPanel)
        Controls.Add(AdditionalSettingsGroupBox)
        Controls.Add(EnvDropdown)
        Controls.Add(Label2)
        Controls.Add(ProjectDropdown)
        Controls.Add(Label1)
        Name = "WinApp"
        Text = "Add Appsettings"
        AdditionalSettingsGroupBox.ResumeLayout(False)
        AdditionalSettingsGroupBox.PerformLayout()
        BottomPanel.ResumeLayout(False)
        BottomPanel.PerformLayout()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents AddButton As Button
    Friend WithEvents ProjectDropdown As ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents EnvDropdown As ComboBox
    Friend WithEvents MainPathLabel As Label
    Friend WithEvents MainLocationTextBox As TextBox
    Friend WithEvents FolderBrowserDialog1 As FolderBrowserDialog
    Friend WithEvents BrowseButton As Button
    Friend WithEvents AdditionalSettingsGroupBox As GroupBox
    Friend WithEvents CheckBoxLocalSettings As CheckBox
    Friend WithEvents FunctionsComboBox As ComboBox
    Friend WithEvents Label3 As Label
    Friend WithEvents BottomPanel As Panel
    Friend WithEvents LoadFunctionsButton As Button

End Class
