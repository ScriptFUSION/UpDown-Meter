#include <idp.iss>

#define SourceRoot SourcePath + "\..\Source"
#define OutputDir SourceRoot + "\bin\Release"

#define MyAppName "UpDown Meter"
#define MyAppExeName MyAppName + ".exe"
#define MyAppVersion RemoveFileExt(GetFileVersion(OutputDir + "\" + MyAppExeName))
#define MyAppPublisher "ScriptFUSION"
#define MyAppURL "https://github.com/ScriptFUSION/UpDown-Meter"

[Setup]
AppId={{8DCBF5FF-5AEB-4860-AED4-CAFA2FF258F9}
AppName={#MyAppName}
AppVersion={#MyAppVersion}
AppPublisher={#MyAppPublisher}
AppPublisherURL={#MyAppURL}
AppSupportURL={#MyAppURL}
AppUpdatesURL={#MyAppURL}
DefaultDirName={pf}\{#MyAppPublisher}\{#MyAppName}
DefaultGroupName={#MyAppPublisher}\{#MyAppName}
LicenseFile={#SourceRoot}\..\LICENSE
OutputDir={#OutputDir}
OutputBaseFilename={#MyAppName} {#MyAppVersion} setup
AllowNoIcons=yes
SolidCompression=yes

[Languages]
Name: "english"; MessagesFile: "compiler:Default.isl"

[Tasks]
Name: "desktopicon"; Description: "{cm:CreateDesktopIcon}"; GroupDescription: "{cm:AdditionalIcons}"; Flags: unchecked
Name: "quicklaunchicon"; Description: "{cm:CreateQuickLaunchIcon}"; GroupDescription: "{cm:AdditionalIcons}"; Flags: unchecked; OnlyBelowVersion: 0,6.1

[Files]
Source: "{#OutputDir}\{#MyAppExeName}"; DestDir: "{app}"; Flags: ignoreversion
Source: "{#OutputDir}\*.dll"; DestDir: "{app}"; Flags: ignoreversion

[Icons]
Name: "{group}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"
Name: "{group}\{cm:ProgramOnTheWeb,{#MyAppName}}"; Filename: "{#MyAppURL}"
Name: "{group}\{cm:UninstallProgram,{#MyAppName}}"; Filename: "{uninstallexe}"
Name: "{commondesktop}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"; Tasks: desktopicon
Name: "{userappdata}\Microsoft\Internet Explorer\Quick Launch\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"; Tasks: quicklaunchicon

[Run]
Filename: "{app}\{#MyAppExeName}"; Description: "{cm:LaunchProgram,{#MyAppName}}"; Flags: nowait postinstall skipifsilent

[Code]
var
  dotNetInstaller: string;

procedure InitializeWizard;
var
  netVersion: cardinal;
begin
  dotNetInstaller := ExpandConstant('{tmp}\NetFrameworkInstaller.exe');

  RegQueryDWordValue(HKLM, 'Software\Microsoft\NET Framework Setup\NDP\v4\Full', 'Release', netVersion)

  // .NET Framework version < 4.5.1.
  if (netVersion < 378675) then begin
    // Download .NET Framework 4.5.2 Web installer.
    idpAddFile('http://go.microsoft.com/fwlink/?LinkId=397707', dotNetInstaller);
    idpDownloadAfter(wpReady);
  end;
end;

procedure InstallFramework;
var
  StatusText: string;
  ResultCode: Integer;
begin
  if not FileExists(dotNetInstaller) then exit;

  StatusText := WizardForm.StatusLabel.Caption;
  WizardForm.StatusLabel.Caption := 'Installing .NET Framework 4.5.2. This may take a few minutes...';
  WizardForm.ProgressGauge.Style := npbstMarquee;
  try
    if not Exec(dotNetInstaller, '/passive /norestart', '', SW_SHOW, ewWaitUntilTerminated, ResultCode) then begin
      MsgBox('.NET Framework installation failed: ' + SysErrorMessage(ResultCode) + ' (#' + IntToStr(ResultCode) + ').', mbError, MB_OK);
    end;
  finally
    WizardForm.StatusLabel.Caption := StatusText;
    WizardForm.ProgressGauge.Style := npbstNormal;

    DeleteFile(dotNetInstaller);
  end;
end;

procedure CurStepChanged(CurStep: TSetupStep);
begin
  // Install .NET Framework before program files.
  if CurStep = ssInstall then InstallFramework;
end;
