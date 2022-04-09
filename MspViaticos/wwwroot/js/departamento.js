window.onload = function () {
    listarDepartamentos();
    /*validarKeyPress("frmGuardarDepartamento")*/
}

var objGlobalDepartamento;
async function listarDepartamentos() {

    objGlobalDepartamento = {
        popup: true,
        popupId: "staticBackdrop",
        url: "Departamento/listarDepartamento",
        divPintado: "divContenedor",
        cabeceras: ["Registro","Codigo", "Nombre"],
        propiedades: ["registro", "codigo", "nombre"],
        divContenedorTabla: "contenedorTabla",
        editar: true,
        eliminar: true,
        propiedadId: "registro",
        paginar: true
    }
    pintar(objGlobalDepartamento)
}

//async function GuardarDatos() {
//    var frmGuardar = document.getElementById("frmGuardarActividades")
//    var frm = new FormData(frmGuardar);
//    await fetchPost("Actividades/Guardardatos", "text", frm, function (data) {
//        if (data == "1") {
//            listarActividades();
//            LimpiarDatos("frmGuardarActividades");
//        }
//    })
//}

//function Limpiar() {
//    LimpiarDatos("frmGuardarActividades")
//}

function GuardarDatos() {

    var errores = ValidarDatos("frmGuardarDepartamento")
    if (errores != "") {
        Error(errores)
        return;
    }

    var frmGuardar = document.getElementById("frmGuardarDepartamento")
    var frm = new FormData(frmGuardar);
    Confirmacion(undefined, "Desea guardar los departamentos?", function () {
        fetchPost("Departamento/guardarDepartamentos", "text", frm, function (data) {
            if (data == "1") {
                Exito();
                listarDepartamentos();
                LimpiarDatos("frmGuardarDepartamento");
            } else Error();
        })
    })
}

function Editar(registro) {
    LimpiarDatos("frmGuardarDepartamento");
    if (registro == 0) {
        setI("lblTitulo", "Agregar Departamento")
    } else {
        setI("lblTitulo", "Editar Departamento")
        recuperarGenerico("Departamento/recuperarDepartamento/?registro=" + registro, "frmGuardarDepartamento")
    }
    
}
