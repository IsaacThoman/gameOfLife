Public Class Form1

    Dim cells(36, 36) As Boolean
    Dim iterationCount As Integer
    Dim timerOn As Boolean


    Function doIteration()
        Dim neighbors(35, 35) As Integer
        For fillerx As Integer = 1 To 35
            For fillery As Integer = 1 To 35

                Dim myX As Integer = fillerx
                Dim myY As Integer = fillery


                If cells(myX + 1, myY + 1) = True Then
                    neighbors(myX, myY) += 1
                End If
                If cells(myX + 1, myY) = True Then
                    neighbors(myX, myY) += 1
                End If
                If cells(myX + 1, myY - 1) = True Then
                    neighbors(myX, myY) += 1
                End If
                If cells(myX, myY - 1) = True Then
                    neighbors(myX, myY) += 1
                End If
                If cells(myX - 1, myY - 1) = True Then
                    neighbors(myX, myY) += 1
                End If
                If cells(myX - 1, myY) = True Then
                    neighbors(myX, myY) += 1
                End If
                If cells(myX - 1, myY + 1) = True Then
                    neighbors(myX, myY) += 1
                End If
                If cells(myX, myY + 1) = True Then
                    neighbors(myX, myY) += 1
                End If



            Next
        Next


        For changerx As Integer = 1 To 35
            For changery As Integer = 1 To 35

                Dim myX As Integer = changerx
                Dim myY As Integer = changery

                If cells(myX, myY) = True And neighbors(myX, myY) < 2 Then
                    cells(myX, myY) = False
                End If

                If cells(myX, myY) = True And neighbors(myX, myY) = 2 Then
                    cells(myX, myY) = True
                End If

                If cells(myX, myY) = True And neighbors(myX, myY) = 3 Then
                    cells(myX, myY) = True
                End If

                If cells(myX, myY) = True And neighbors(myX, myY) > 3 Then
                    cells(myX, myY) = False
                End If

                If cells(myX, myY) = False And neighbors(myX, myY) = 3 Then
                    cells(myX, myY) = True
                End If






            Next
        Next

        iterationCount += 1
        iterationLabel.Text = "Iterations: " & iterationCount

    End Function


    Function renderer()
        Dim surface As Graphics = CreateGraphics()
        Dim solidBrushGreen As SolidBrush = New SolidBrush(Color.Green)
        Dim solidBrushLightGray As SolidBrush = New SolidBrush(Color.LightGray)
        Dim solidBrushDarkGray As SolidBrush = New SolidBrush(Color.DarkGray)
        Dim solidBrushBlack As SolidBrush = New SolidBrush(Color.Black)

        Dim rects(35, 35) As Rectangle






        Dim ModCheck
        For fillerx = 1 To 35
            For fillery = 1 To 35
                rects(fillerx, fillery) = New Rectangle((fillerx * 15) + 300 - 15, (fillery * 15) + 7, 15, 15)

                ModCheck = (fillerx + fillery) Mod 2



                If ModCheck = 0 Then
                    surface.FillRectangle(solidBrushLightGray, rects(fillerx, fillery))
                Else
                    surface.FillRectangle(solidBrushDarkGray, rects(fillerx, fillery))
                End If

                If cells(fillerx, fillery) = True Then
                    surface.FillRectangle(solidBrushGreen, rects(fillerx, fillery))
                End If
                If fillerx = 1 Or fillery = 1 Or fillerx = 35 Or fillery = 35 Then
                    surface.FillRectangle(solidBrushBlack, rects(fillerx, fillery))
                End If


            Next
        Next




    End Function


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        doIteration()
        renderer()

    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Form1_MouseClick(sender As Object, e As MouseEventArgs) Handles Me.MouseClick
        Dim xSel As Integer = (MousePosition.X - Me.Left) / 15 - 20
        Dim ySel As Integer = (MousePosition.Y - Me.Top) / 15 - 3


        If xSel > 0 And ySel > 0 And xSel < 35 And ySel < 35 Then



            If cells(xSel, ySel) = True Then
                cells(xSel, ySel) = False
            Else
                cells(xSel, ySel) = True
            End If
            renderer()
        End If


        ' Button1.Text = xSel & ", " & ySel
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        For clearX = 1 To 35
            For clearY = 1 To 35
                cells(clearX, clearY) = False




            Next
        Next
        renderer()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If timerOn = True Then
            doIteration()
            renderer()
            Timer1.Enabled = True

        Else
            Timer1.Enabled = False
        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        timerOn = True
        Timer1.Enabled = True
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        timerOn = False
        Timer1.Enabled = False
    End Sub

    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton1.CheckedChanged
        If RadioButton1.Checked Then
            Timer1.Interval = 1000
        End If

    End Sub

    Private Sub RadioButton10_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton10.CheckedChanged
        If RadioButton10.Checked Then
            Timer1.Interval = 200
        End If
    End Sub

    Private Sub RadioButton20_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton20.CheckedChanged
        If RadioButton20.Checked Then
            Timer1.Interval = 100
        End If
    End Sub

    Private Sub RadioButton100_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton100.CheckedChanged
        If RadioButton20.Checked Then
            Timer1.Interval = 1
        End If
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Me.Close()
    End Sub
End Class
