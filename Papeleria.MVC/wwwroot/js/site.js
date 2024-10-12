// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
let selectArticuloPedido = document.querySelector("#selectArticulo");
let spanArticuloPrecio = document.querySelector("#spanPrecioArticulo");

selectArticuloPedido.addEventListener("change", function ()
{
    let PrecioArticuloSeleccionado = selectArticuloPedido.options[selectArticuloPedido.selectedIndex]
        .getAttribute("data-precio");
    spanArticuloPrecio.innerHTML = "$ "+PrecioArticuloSeleccionado;    
});


d
