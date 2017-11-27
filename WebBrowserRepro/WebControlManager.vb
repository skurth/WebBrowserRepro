
Option Strict Off

Imports Microsoft.Win32

Public Class WebControlManager

  Public Shared Sub IEbrowserFix()
    'SetRegistryKeyUser("WebBrowserRepro.exe", "SOFTWARE\Microsoft\Internet Explorer\Main\FeatureControl\FEATURE_BROWSER_EMULATION")
    'SetRegistryKeyUser("WebBrowserRepro64.exe", "SOFTWARE\Microsoft\Internet Explorer\Main\FeatureControl\FEATURE_BROWSER_EMULATION")
    'SetRegistryKeyUser("WebBrowserRepro.exe", "SOFTWARE\Wow6432Node\Microsoft\Internet Explorer\MAIN\FeatureControl\FEATURE_BROWSER_EMULATION")
    'SetRegistryKeyUser("WebBrowserRepro64.exe", "SOFTWARE\Wow6432Node\Microsoft\Internet Explorer\MAIN\FeatureControl\FEATURE_BROWSER_EMULATION")

    EnsureBrowserEmulationEnabled("WebBrowserRepro.exe")
    EnsureBrowserEmulationEnabled("WebBrowserRepro64.exe")
  End Sub

  Public Shared Sub EnsureBrowserEmulationEnabled(Optional exename As String = "MarkdownMonster.exe", Optional uninstall As Boolean = False)
    Try
      Using rk = Registry.CurrentUser.OpenSubKey("SOFTWARE\Microsoft\Internet Explorer\Main\FeatureControl\FEATURE_BROWSER_EMULATION", True)
        If Not uninstall Then
          Dim value = rk.GetValue(exename)
          If value Is Nothing Then
            rk.SetValue(exename, CUInt(11001), RegistryValueKind.DWord)
          End If
        Else
          rk.DeleteValue(exename)
        End If
      End Using
    Catch
    End Try
  End Sub


  'Private Shared Sub SetRegistryKeyUser(ByVal appName As String, ByVal KeyPath As String)
  '  Try
  '    Dim regDM As Microsoft.Win32.RegistryKey

  '    Dim iKeyValue As Integer = 0
  '    Dim ieVersion As New Version

  '    If Version.TryParse(Registry.CurrentUser.OpenSubKey("Software\Microsoft\Internet Explorer").GetValue("Version").ToString(), ieVersion) Then
  '      If ieVersion.Minor <= 10 Then
  '        iKeyValue = 10000
  '      ElseIf ieVersion.Minor = 11 Then
  '        iKeyValue = 11000
  '      ElseIf ieVersion.Minor = 12 Then
  '        iKeyValue = 12000
  '      ElseIf ieVersion.Minor = 13 Then
  '        iKeyValue = 13000
  '      ElseIf ieVersion.Minor = 14 Then
  '        iKeyValue = 14000
  '      End If
  '    End If

  '    regDM = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(KeyPath, False)
  '    If regDM Is Nothing Then
  '      regDM = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(KeyPath)
  '    End If

  '    Dim Sleutel As Object
  '    Dim bCreateKey As Boolean = False
  '    If Not regDM Is Nothing Then
  '      Sleutel = regDM.GetValue(appName)
  '      If Sleutel IsNot Nothing Then
  '        If Sleutel <> iKeyValue Then
  '          bCreateKey = True
  '        End If
  '      Else
  '        bCreateKey = True
  '      End If

  '      If bCreateKey Then
  '        regDM = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(KeyPath, True)
  '        Sleutel = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(KeyPath, Microsoft.Win32.RegistryKeyPermissionCheck.ReadWriteSubTree)

  '        Sleutel.SetValue(appName, iKeyValue, Microsoft.Win32.RegistryValueKind.DWord)

  '        Sleutel.Close()

  '        regDM.Flush()
  '      End If
  '      regDM.Close()
  '    End If
  '  Catch ex As Exception
  '    ex = ex
  '  End Try
  'End Sub

  Private Shared Sub SetRegistryKey(ByVal appName As String, ByVal KeyPath As String)
    Try
      Dim regDM As Microsoft.Win32.RegistryKey

      Dim iKeyValue As Integer = 0
      Dim ieVersion As New Version
      If Version.TryParse(Registry.LocalMachine.OpenSubKey("Software\Microsoft\Internet Explorer").GetValue("Version").ToString(), ieVersion) Then
        If ieVersion.Minor <= 10 Then
          iKeyValue = 10000
        ElseIf ieVersion.Minor = 11 Then
          iKeyValue = 11000
        ElseIf ieVersion.Minor = 12 Then
          iKeyValue = 12000
        ElseIf ieVersion.Minor = 13 Then
          iKeyValue = 13000
        ElseIf ieVersion.Minor = 14 Then
          iKeyValue = 14000
        End If
      End If

      regDM = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(KeyPath, False)
      If regDM Is Nothing Then
        regDM = Microsoft.Win32.Registry.LocalMachine.CreateSubKey(KeyPath)
      End If

      Dim Sleutel As Object
      Dim bCreateKey As Boolean = False
      If Not regDM Is Nothing Then
        Sleutel = regDM.GetValue(appName)
        If Sleutel IsNot Nothing Then
          If Sleutel <> iKeyValue Then
            bCreateKey = True
          End If
        Else
          bCreateKey = True
        End If

        If bCreateKey Then
          regDM = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(KeyPath, True)
          Sleutel = Microsoft.Win32.Registry.LocalMachine.CreateSubKey(KeyPath, Microsoft.Win32.RegistryKeyPermissionCheck.ReadWriteSubTree)

          Sleutel.SetValue(appName, iKeyValue, Microsoft.Win32.RegistryValueKind.DWord)

          Sleutel.Close()

          regDM.Flush()
        End If
        regDM.Close()
      End If
    Catch ex As Exception
    End Try
  End Sub

  'What OS are we using
  'Dim OsVersion As Version = System.Environment.OSVersion.Version
  'If OsVersion.Major = 6 And OsVersion.Minor = 1 Then
  '  'WIN 7
  '  Sleutel.SetValue(appName, 9000, Microsoft.Win32.RegistryValueKind.DWord)
  'ElseIf OsVersion.Major = 6 And OsVersion.Minor = 2 Then

  'ElseIf OsVersion.Major = 5 And OsVersion.Minor = 1 Then
  '  'WIN xp
  '  Sleutel.SetValue(appName, 8000, Microsoft.Win32.RegistryValueKind.DWord)
  'End If

End Class