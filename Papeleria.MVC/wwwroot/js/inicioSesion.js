let loadingInicioSesion = document.querySelector("#loadingIniciarSesion");
loadingInicioSesion.style.display = 'none';
document.querySelector("#btnIniciarSesion").addEventListener('click', function () {
    loadingInicioSesion.style.display = 'block';
});
function DisiparLoading(id) {
    document.querySelector("#" + id).style.display = 'none';
}