window.onload = function () {
    listarDependencias();
}

var objGlobalDependencia;
async function listarDependencias() {

    objGlobalDependencia = {
        popup: true,
        popupId: "staticBackdrop",
        url: "Dependencia/listarDependencias",
        divPintado: "divContenedor",
        cabeceras: ["Registro", "Codigo", "Nombre", "Director Administrativo"],
        propiedades: ["registro", "codigo", "nombre", "directorAdministrativo"],
        divContenedorTabla: "contenedorTabla",
        editar: true,
        eliminar: true,
        propiedadId: "registro",
        paginar:true
    }
    pintar(objGlobalDependencia)
}


function GuardarDatos() {

    var errores = ValidarDatos("frmGuardarDependencia")
    if (errores != "") {
        Error(errores)
        return;
    }

    var frmGuardar = document.getElementById("frmGuardarDependencia")
    var frm = new FormData(frmGuardar);
    Confirmacion(undefined, "Desea guardar los departamentos?", function () {
        fetchPost("Dependencia/guardarDependencia", "text", frm, function (data) {
            if (data == "1") {
                Exito();
                listarDepartamentos();
                LimpiarDatos("frmGuardarDependencia");
            } else Error();
        })
    })
}

function Editar(registro) {
    LimpiarDatos("frmGuardarDependencia");
    if (registro == 0) {
        setI("lblTitulo", "Agregar Dependencia")
    } else {
        setI("lblTitulo", "Editar Dependencia")
        recuperarGenerico("Dependencia/recuperarDependencia/?registro=" + registro, "frmGuardarDependencia")
    }

}