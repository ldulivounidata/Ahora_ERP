' Crear un nuevo TAB
' 
' Se llama a la función que crea el TAB en el Initialize.
' La función espera el nombre del objeto, el nombre a mostrar y el objeto padre.

Sub Initialize()
    CreaTabNuevo "persObjeto", "NombreMostrar", "Padre", 402 
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