Public Class Form1

    Dim cells(35, 35) As Boolean
    Dim iterationCount As Integer
    Dim timerOn As Boolean


    Function doIteration()

        For fillerx = 1 To 35
            For fillery = 1 To 35





            Next
        Next


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
End Class
