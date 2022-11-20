// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
var count = 0;
function adicionar_campo()
{
    count+= 1;
    html = '<div class = "row" id = "row'+count+'">\
                <div class = "col-8">\
                    <label>Nome do Produto</label>\
                    <input asp-for = "Venda.Produtos" name = "Venda.Produtos['+count+'].Nome" class = "form-control"/>\
                </div>\
            </div>'


    var form = document.getElementById('product_form')
    form.innerHTML += html
} 