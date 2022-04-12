Attribute VB_Name = "Module1"
Option Explicit

Sub Main()

    Dim CSVLocation As String
    Dim CSVname As String
    Dim IRow As Long
    Dim CSVFile As String
    Dim ComputerName As String
    Dim UserName As String
    Dim ComputerRow As Long
    Dim LastRow As Long
    Dim TodayDate As Date
    Dim tbl As ListObject
    Dim newrow As ListRow
    Dim rng As Range
    
    'Main module
    CSVLocation = ThisWorkbook.Sheets("Tabelle1").Cells(1, 2).Value
    CSVname = "Update_Assets"
    Workbooks.Open CSVLocation
    CSVFile = ActiveWorkbook.Name
    ComputerExists = True
    LastRow = ThisWorkbook.Sheets("Tabelle1").Cells(1, 1).End(xlDown).Row
    TodayDate = Date
    Set tbl = ThisWorkbook.Sheets("Tabelle1").ListObjects("Dells")
    
    
    IRow = 2
    Do Until Workbooks(CSVFile).Sheets(CSVname).Cells(IRow, 1).Value = ""
        ComputerName = Workbooks(CSVFile).Sheets(CSVname).Cells(IRow, 1).Value
        UserName = Workbooks(CSVFile).Sheets(CSVname).Cells(IRow, 2).Value
        If Right(UserName, 4) = ".ext" Then
            UserName = Left(UserName, Len(UserName) - 4)
        End If
        If Right(UserName, 4) = "-adm" Or UserName = "_admin" Then
            UserName = "Spare"
        End If
        UserName = Replace(UserName, ".", " ")
        UserName = WorksheetFunction.Proper(UserName)
        
        If Trim(ComputerName) <> "" Then
            With ThisWorkbook.Sheets("Tabelle1").Columns("A:A")
                Set rng = .Find(what:=ComputerName, _
                            After:=.Cells(.Cells.Count), _
                            LookIn:=xlValues, _
                            lookat:=xlWhole, _
                            searchorder:=xlByRows, _
                            searchdirection:=xlNext, _
                            MatchCase:=False)
                If Not rng Is Nothing Then
                    'MsgBox "found"
                    ComputerRow = ThisWorkbook.Sheets("Tabelle1").Columns("A:A").Find(what:=ComputerName).Row
                Else
                    'MsgBox "nope"
                    Set newrow = tbl.ListRows.Add
                    With newrow
                        .Range(1) = ComputerName
                        .Range(3) = TodayDate
                        .Range(4) = UserName
                        .Range(8) = "Shiseido UK"
                    End With
                End If
            End With
        End If
        
        If ThisWorkbook.Sheets("Tabelle1").Cells(ComputerRow, 4).Value <> UserName Then
            ThisWorkbook.Sheets("Tabelle1").Cells(ComputerRow, 4).Value = UserName
        End If
        IRow = IRow + 1
    Loop
    
    Workbooks(CSVFile).Close SaveChanges:=False

End Sub



