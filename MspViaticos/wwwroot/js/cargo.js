window.onload = function () {
    listarCargos();
    listarCombo();
}

var objGlobalCargo;
async function listarCargos() {

    objGlobalCargo = {
        popup: true,
        popupId: "staticBackdrop",
        url: "Cargo/listarCargos",
        divPintado: "divContenedor",
        cabeceras: ["Registro", "Codigo", "Descripcion", "Grupos"],
        propiedades: ["registro", "codigo", "descripcion", "grupoDescripcion"],
        divContenedorTabla: "contenedorTabla",
        editar: true,
        eliminar: true,
        propiedadId: "registro",
        paginar: true
    }
    pintar(objGlobalCargo)
}


function listarCombo() {
    fetchGet("Cargo/listarGrupos", "json", function (res) {
        console.log(res.listaGrupo);
        var listarGrupo = res.listaGrupo;
        llenarCombo(listarGrupo, ["cboGrupo"], "descripcion", "codigo", "--Todos--", "0")
    })
}


function GuardarDatos() {

    var errores = ValidarDatos("frmGuardarCargo")
    if (errores != "") {
        Error(errores)
        return;
    }

    var frmGuardar = document.getElementById("frmGuardarCargo")
    var frm = new FormData(frmGuardar);
    Confirmacion(undefined, "Desea guardar los cargos?", function () {
        fetchPost("Cargo/guardarCargo", "text", frm, function (data) {
            if (data == "1") {
                Exito();
                listarCargos();
                LimpiarDatos("frmGuardarCargo");
            } else Error();
        })
    })
}

function Editar(registro) {
    LimpiarDatos("frmGuardarCargo");
    if (registro == 0) {
        setI("lblTitulo", "Agregar Cargo")
    } else {
        setI("lblTitulo", "Editar Cargo")
        recuperarGenerico("Cargo/recuperarCargo/?registro=" + registro, "frmGuardarCargo")
    }

}
