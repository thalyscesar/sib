$(document).ready(function () {

    (function loadEmpresas() {

         $.getJSON("http://localhost:59699/api/empresa",function(data){

            $(data).each(function () {

                incluirEmpresa(this)
            });

        })
    })();

});

function incluirEmpresa(empresa) {
    
    var tabela = $("#gridEmpresa");

    var linha = $('<tr>');
    var cols = "";

    cols += "<td> " + empresa.razaoSocial + " </td>"
    cols += "<td> " + empresa.nomeFantasia + " </td>"
    cols += "<td> " + empresa.cnpj + " </td>"
    cols += "<td> " + empresa.naturezaJuridica + " </td>"
    cols += "<td> " + formatSituacao(empresa.ativa) + " </td>"
    cols += "<td> " + empresa.telefone + " </td>"

    linha.append(cols);
    tabela.append(linha)

}

function formatSituacao(ativa){

    if(ativa) {
        return "Ativa";
    }
    else{
        return "Inativa";
    }
}

