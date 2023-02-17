' '############################################################
'   Añade botones inferiores.
' '############################################################
Sub anadeBotonesDesMarcar()
    With gForm.Controls("Botonera")
        ' .SeguridadObjeto = 0 'No muestra los botones estándar de objeto
        .BotonAdd "Enviar Avisos", "AceptarButton", , 0, True, 103
        .BotonAdd "Marcar todo", "MarcarTodoButton", , 0, True, 104
        .BotonAdd "Desmarcar todo", "DesmarcarTodoButton", , 0, True, 105
        .botonesMantenimiento = 4 ' Mostramos el botón cerrar
        .habilitaBotones
    End With
End Sub

' '############################################################
'   Función que marca todos los check del grid.
' '############################################################
Sub marcarTodasLineas()
    Set lGrid = gForm.Controls("grdMtmto")(0)           ' Nombre del objeto GRID
	Set lArr = lgrid.ArrayDb
    For i = lArr.Lowerbound(1) To lArr.UpperBound(1)
        lArr(i, lGrid.Colindex("@Marca")) = -1
    Next
    lGrid.Grid.Rebind
End Sub

' '############################################################
'   Función que desmarca todos los check del grid.
' '############################################################
Sub desmarcarTodasLineas()
    Set lGrid = gForm.Controls("grdMtmto")(0)           ' Nombre del objeto GRID
	Set lArr = lgrid.ArrayDb
    For i = lArr.Lowerbound(1) To lArr.UpperBound(1)
        lArr(i, lGrid.Colindex("@Marca")) = 0
    Next
    lGrid.Grid.Rebind
End Sub

' '############################################################
'   Detecta si un botón fue pulsado.
' '############################################################
Sub Botonera_AfterExecute(aBotonera, aBoton)
    If aBotonera.name = "Botonera" Then             ' Detecta si es un botón de la Botonera estandar inferior.
        If aBoton.name = "MarcarTodoButton" Then
            marcarTodasLineas
        ElseIf aBoton.name = "DesmarcarTodoButton" Then
            desmarcarTodasLineas
        ' ElseIf aBoton.name = "AceptarButton" Then
        '     AceptarTodoButton
        End If
    End If
End Sub