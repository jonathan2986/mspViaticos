window.onload = function () {
    listarActividades();

}

var objGlobalActividades;
async function listarActividades() {

    objGlobalActividades = {
        url: "Actividades/listarActividades",
        divPintado:"divContenedor",
        cabeceras: ["Codigo", "Descripcion", "Estatus"],
        propiedades: ["codigo", "descripcion", "estatusDescripcion"],
        divContenedorTabla: "contenedorTabla",
        editar: true,
        eliminar: true,
        propiedadId:"registro"
    }
    pintar(objGlobalActividades)
}

function GuardarDatos() {

    var errores = ValidarDatos("frmGuardarActividades")
    if (errores != "") {
        Error(errores)
        return;
    }

    var frmGuardar = document.getElementById("frmGuardarActividades")
    var frm = new FormData(frmGuardar);
    Confirmacion(undefined, undefined, function (rpta) {
        fetchPost("Actividades/Guardardatos", "text", frm, function (data) {
            if (data == "1") {
                Exito();
                listarActividades();
                LimpiarDatos("frmGuardarActividades");
            } else Error();
        })
    })
}


function filtrarActividades() {
    var nombre = get("txtnombrebusqueda");

    if (nombre == "") {
        listarActividades();
    } else {
        objGlobalActividades.url = "Actividades/filtrarActividad/?nombreActividad=" + nombre;
        pintar(objGlobalActividades);
    }
}

function Limpiar() {
    LimpiarDatos("frmGuardarActividades")
    listarActividades();
}

function Editar(registro) {
    recuperarGenerico("Actividades/recuperarActividad/?registro=" + registro, "frmGuardarActividades")
    //fetchGet("TipoMedicamento/recuperarTipomedicamento/?iidtipomedicamento=" + id, "json", function (data) {
    //    setN("idtipomedicamento", data.idtipomedicamento)
    //    setN("nombre", data.nombre)
    //    setN("descripcion", data.descripcion)
    //})
}

function Eliminar(registro) {
    Confirmacion(undefined, "Desea eliminar la actividad", function (rpta) {
        fetchGet("Actividades/eliminarActividad/?registro=" + registro, "text",  function (data) {
            if (data == "1") {
                Exito("Se elimino correctamente");
                listarActividades();             
            }
        })
    })
}


