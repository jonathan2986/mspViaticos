window.onload = function () {
    listarConfiguracion();
}

async function listarConfiguracion() {

    pintar({
        url: "Configuracion/listarConfiguracion",
        cabeceras: ["Codigo", "Descripcion", "Estatus"],
        propiedades: ["codigo", "descripcion", "estatusDescripcion"]
    })
}