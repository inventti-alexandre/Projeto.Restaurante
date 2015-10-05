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

        var pedido = new Pedido(pedidoId);

        var prato = new Prato($("#comboPrato").val());

        var opcoes = new Array();
        $(".cbOpcoes:checked").each(function () {
            opcoes.push(new Opcao($(this).val()));
        });

        var item = new Item(pedido, prato, opcoes);

        $.ajax({
            type: "POST",
            url: "/Projeto.Restaurante.WebApi/Api/V1/ServicoItens/",
            data: JSON.stringify(item),
            dataType: "json",
            contentType: "application/json;charset=utf-8",
            success: function (data) {
                alert("Sucesso!");
                $(".cbOpcoes").removeAttr("checked");
                Listar();
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
        url: "/Projeto.Restaurante.WebApi/Api/V1/ServicoItens/" + pedidoId,
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