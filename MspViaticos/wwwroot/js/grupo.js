window.onload = function () {
    listarGrupos();
}

var objGlobalGrupo;
async function listarGrupos() {

    objGlobalGrupo = {
        popup: true,
        popupId: "staticBackdrop",
        url: "Grupo/listarGrupos",
        divPintado: "divContenedor",
        cabeceras: ["Codigo", "Descripcion", "Tarifa", "Desayuno", "Almuerzo", "Cena", "Alojamiento", "Estatus"],
        propiedades: ["codigo", "descripcion", "tarifa", "desayuno", "almuerzo", "cena", "alojamiento", "estatusDescripcion"],
        divContenedorTabla: "contenedorTabla",
        editar: true,
        eliminar: true,
        propiedadId: "registro"
    }
    pintar(objGlobalGrupo)
}

function GuardarDatos() {

    var errores = ValidarDatos("frmGuardarGrupo")
    if (errores != "") {
        Error(errores)
        return;
    }

    var frmGuardar = document.getElementById("frmGuardarGrupo")
    var frm = new FormData(frmGuardar);
    Confirmacion(undefined, undefined, function (rpta) {
        fetchPost("Grupo/guardarGrupos", "text", frm, function (data) {
            if (data == "1") {
                Exito();
                listarGrupos();
                LimpiarDatos("frmGuardarGrupo");
            } else Error();
        })
    })
}

//function Limpiar() {
//    LimpiarDatos("frmGuardarActividades")
//}

