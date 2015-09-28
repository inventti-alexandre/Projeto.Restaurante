var pedidoId = 0;

function SetPedidoId(id) {
    pedidoId = id;
}

function Validacao() {
    if ($("#comboPrato option").length === 0 || $("#comboPrato").val() === "0") {
        alert("Prato - Obrigatório");
        return false;
    }
    return true;
}

function AssociarItem() {
    if (Validacao()) {

        var viewModelPostOpcao = new Array();
        $(".checkbox:checked").each(function () {
            viewModelPostOpcao.push($(this).val());
        });

        var viewModelPostItem = new ViewModelPostItem(pedidoId, $("#comboPrato").val());

        $.ajax({
            type: "POST",
            url: "/Api/V1/Itens",
            data: JSON.stringify(viewModelPostItem),
            dataType: "json",
            contentType: "application/json;charset=utf-8",
            success: function (data) {
                alert("Sucesso!");

            },
            error: function (jqXhr) {
                var e = eval("(" + jqXhr.responseText + ")");
                alert(e.Message);
            }
        });
    }
}

function Listar() {
    $("#tblItens").hide();

    $.ajax({
        type: "GET",
        url: "/Api/V1/Itens/" + pedidoId,
        dataType: "json",
        contentType: "application/json;charset=utf-8",
        success: function (e) {
            if (e != null && e.length > 0) {
                var list = "";
                $.each(e, function (key, val) {
                    list += "<tr>";
                    list += "<td>";
                    list += val.prato.nome;
                    list += "</td>";
                    list += "<td>";
                    $(val.opcoes).each(function() {
                        list += this.nome;
                    });
                    list += "</td>";
                    list += "</tr>";
                });
                $("#tblItens tbody").html(list);
                $("#tblItens").show();
            }
        },
        error: function (jqXhr) {
            var e = eval("(" + jqXhr.responseText + ")");
            alert(e.Message);
        }
    });
}