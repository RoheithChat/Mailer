Imports System.IO
Imports System.Text.Json

Public Class Settings
    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim jsonString As String = File.ReadAllText("info.json")
        Dim options As JsonSerializerOptions = New JsonSerializerOptions With {
            .PropertyNameCaseInsensitive = True
             }
        Dim info As Person = JsonSerializer.Deserialize(Of Person)(jsonString, options)

        If ComboBox1.Text = "Gmail" Then
            info.provider = "gmail"
            Dim updatedJsonString As String = JsonSerializer.Serialize(info)
            File.WriteAllText("info.json", updatedJsonString)
        ElseIf ComboBox1.Text = "Outlook" Then
            info.provider = "outlook"
            Dim updatedJsonString As String = JsonSerializer.Serialize(info)
            File.WriteAllText("info.json", updatedJsonString)
        ElseIf ComboBox1.Text = "Yahoo" Then
            info.provider = "yahoo"
            Dim updatedJsonString As String = JsonSerializer.Serialize(info)
            File.WriteAllText("info.json", updatedJsonString)
        Else
            MsgBox("Invalid Selection")
        End If
        Form1.ChangetheProvider()


    End Sub
    Public Class Person
        Public Property provider As String
    End Class
End Class