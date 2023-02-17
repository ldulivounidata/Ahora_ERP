' Crear un nuevo TAB
' 
' Se llama a la función que crea el TAB en el Initialize.
' La función espera el nombre del objeto, el nombre a mostrar y el objeto padre.

Sub Initialize()
    CreaTabNuevo "persObjeto", "NombreMostrar", "TabMain", 402 
End Sub

'############################################################
' Función que crea un nuevo TAB
' 
' nombreObjeto:     Es el nombre del objeto dentro del ControlF10
' nombreMostrar:    Es el Texto a mostrar en la vista
' nombrePadre:      Es el objeto padre. Ej: TabMain, TabPrincipal.
' numberTab:        Es el número del objeto.
'############################################################
Sub CreaTabNuevo(nombreObjeto, nombreMostrar, nombrePadre, numberTab)
    Set lTab = gForm.Controls.add("Threed.SSPanel", nombreObjeto)
    lTab.Visible=True
    lTab.autosize=3
    gForm.Controls(nombrePadre).InsertItem "" & numberTab, "" & nombreMostrar, lTab.Hwnd, 1 
End Sub

' Crea una GRID nueva
' Esta GRID detecta el nombre de las columnas en la tabla.
' 
' La grid debe estar dentro de un objeto, como por ejemplo un TAB.
' El objeto que contenga la grid, debe estar creada en el Initialize
' La GRID se crea luego en en Show.

Sub Show()
    ' Creado por: Ldulivo
    ' Crea Grid Escandallos dentro de Tab Escandallos
    gridAutoColum "Articulos", "", "persGridAutoColum", "persObjeto", "marca"
End Sub

'############################################################
' Función que crea una nueva GRID
' 
' gridFrom:     El nombre de la tabla
' gridWhere:    El Where de la consulta
' gridName:     El nombre del objeto GRID
' gridPadre:    El padre de la GRID
' gridMarca:    Si está con la palabra 'marca' agrega un check a la grid
'############################################################
Sub gridAutoColum(gridFrom, gridWhere, gridName, gridPadre, gridMarca)
    Set ColObjeto = gCn.OpenResultset("SELECT name FROM sys.all_columns WHERE OBJECT_ID = OBJECT_ID('" & gridFrom & "')")       ' Lee los nombres de las columnas de la tabla
    Set lGridAutoColum = gForm.Controls.Add("AhoraOCX.cntGridUsuario", gridName, gForm.Controls(gridPadre))        ' Agrega la Grid dentro del panel padre (gridPadre)

    lGridAutoColum.Visible=True
    lGridAutoColum.AplicaEstilo
    lGridAutoColum.ActivarScripts = True
    With lGridAutoColum ' NO_TRADUCIR_TAG
        If gridMarca = "marca" Then
            .AgregaColumna "@Marca", 790, "Marca", False
            .Campo("@Marca").Booleano = True
        End If
        While Not ColObjeto.EOF
            nombreColumna = CStr(ColObjeto("name").Value)
            .AgregaColumna nombreColumna, 1500, nombreColumna, True
            ColObjeto.MoveNext
        Wend
        .From = gridFrom
        .Where = gridWhere
        .Agregar = True
        .Editar = True
        .Eliminar = True
        .CargaObjetos = False
        .EditarPorObjeto = False
        .RefrescaSinLoad = True 
        .Refresca = True
    End With
    lGridAutoColum.refresca = True                            ' Refresca la grid para que cargue el campo @Descrip
End Sub