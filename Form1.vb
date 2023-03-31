Imports MAILER.Settings
Imports Microsoft.Web.WebView2.WinForms
Imports System.IO
Imports System.Object
Imports System.Text.Json

Public Class Form1

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        AddHandler Me.Resize, AddressOf Form_Resize
    End Sub

    Private Sub Form_Resize(ByVal sender As Object, ByVal e As EventArgs)
        WebView21.Size = Me.ClientSize - New System.Drawing.Size(WebView21.Location)
    End Sub

    Private Sub ChangeProviderToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ChangeProviderToolStripMenuItem.Click
        Settings.Visible = True
    End Sub
    Public Sub ChangetheProvider()
        Dim jsonString As String = File.ReadAllText("info.json")
        Dim options As JsonSerializerOptions = New JsonSerializerOptions With {
            .PropertyNameCaseInsensitive = True
             }
        Dim info As Person = JsonSerializer.Deserialize(Of Person)(jsonString, options)

        Dim gmailurl As New Uri("http://www.gmail.com")
        Dim outlookurl As New Uri("http://www.outlook.com")
        Dim Yahoourl As New Uri("http://Mail.Yahoo.com")
        If info.provider = "gmail" Then
            WebView21.Source = gmailurl
        ElseIf info.provider = "outlook" Then
            WebView21.Source = outlookurl
        ElseIf info.provider = "yahoo" Then
            WebView21.Source = Yahoourl
        End If
    End Sub
End Class
