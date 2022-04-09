window.onload = function () {
    listarPeriodo();
    listarCombo();
}

var objGlobalPeriodo;
async function listarPeriodo() {

    objGlobalPeriodo = {
        popup: true,
        popupId: "staticBackdrop",
        url: "Periodo/listaPeriodo",
        divPintado: "divContenedor",
        cabeceras: ["Dependencia", "Año", "Mes", "Desde", "Hasta", "Estatus"],
        propiedades: ["nombreDependencia", "anio", "mesDescripcion", "desde", "hasta","estatusDescripcion"],
        divContenedorTabla: "contenedorTabla",
        editar: true,
        eliminar: true,
        propiedadId: "registro",
        paginar: true
    }
    pintar(objGlobalPeriodo)
}


function listarCombo() {
    fetchGet("Periodo/listarCombos", "json", function (res) {
        console.log(res);
        var listaDependencia = res.listaDependencia;
        llenarCombo(listaDependencia, ["cboDependencia"], "nombre", "codigo", "--Todos--", "0")
    })
}


function GuardarDatos() {

    var errores = ValidarDatos("frmGuardarPeriodo")
    if (errores != "") {
        Error(errores)
        return;
    }

    var frmGuardar = document.getElementById("frmGuardarPeriodo")
    var frm = new FormData(frmGuardar);
    Confirmacion(undefined, "Desea guardar el periodo?", function () {
        fetchPost("Periodo/guardarPeriodo", "text", frm, function (data) {
            if (data == "1") {
                Exito();
                listarPeriodo();
                LimpiarDatos("frmGuardarCargo");
            } else Error();
        })
    })
}

function Editar(registro) {
    LimpiarDatos("frmGuardarPeriodo");
    if (registro == 0) {
        setI("lblTitulo", "Agregar Periodo")
    } else {
        setI("lblTitulo", "Editar Periodo")
        /*recuperarGenerico("Cargo/recuperarCargo/?registro=" + registro, "frmGuardarCargo")*/
    }

}
