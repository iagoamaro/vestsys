$(document).ready(function () {

    AtivaSubmit();
    $(document).on('click', '#btPesquisarAbaProdutos-Gerenciar', function () {
    });

    $(document).on('keyup', 'input', function () {
        DesabilitarValidacao(this.id);
        AtivaSubmit();
    });

    
});

function AtivaSubmit() {
    if ($(".campos").val().length == 0) {
        $(".btnsubmit").prop("disabled", true);
    }
    else {
        $(".btnsubmit").prop("disabled", false);
    }

};

function OnBeginusuario_IncOuAlt() {
    console.log("iniciou");
    AtivarSpin();
    //DesativarAlert('AlertAbaProdutos-IncOuAlt');
};

function OnCompleteusuario_IncOuAlt() {
    DesativarSpin();
    console.log("completou");
};

function OnFailureusuario_IncOuAlt(response) {
    //VerificarRetornoAjaxBeginForm(response);
//    DesativarSpin();
    AtivarAlert('warning', 'Ocorreu um erro ao comunicar com o servidor (UI)', 'alertUsuario-IncOuAlt');
    console.log("Falhou");
};

function OnSuccessusuario_IncOuAlt(response) {
    console.log("sucesso");
    if (response.Resposta === 'OK') {
        location.href = '/Usuario/Index';
//        AtivarAlert('success', response.Mensagem, 'alertUsuario-IncOuAlt');

    } else if (response.Resposta === 'VALIDACAO') {
        $('[name="controle_span_errosparceiro"]').remove();
        response.Mensagem.forEach(function (erro) {
            HabilitarValidacao(erro.Campo, erro.Mensagem);
        });
    } else {
        AtivarAlert('warning', response.valid, 'alertUsuario-IncOuAlt');
    }
};


function AtivarAlert(tipo, msg, divContainer) {
    try {
        var _alert;
        switch (tipo) {
            case 'danger':
                _alert = '<div class="alert-dismissible alert alert-' + tipo + '"><button type="button" class="close" data-dismiss="alert" aria-label="Close"><span aria-hidden="true">&times;</span></button><h4><i class="icon fa fa-ban"></i> Atenção!</h4>' + msg + '</div>';
                break;
            case 'info':
                _alert = '<div class="alert-dismissible alert alert-' + tipo + '"><button type="button" class="close" data-dismiss="alert" aria-label="Close"><span aria-hidden="true">&times;</span></button><h4><i class="icon fa fa-info"></i> Atenção!</h4>' + msg + '</div>';
                break;
            case 'success':
                _alert = '<div class="alert-dismissible alert alert-' + tipo + '"><button type="button" class="close" data-dismiss="alert" aria-label="Close"><span aria-hidden="true">&times;</span></button><h4><i class="icon fa fa-check"></i> Atenção!</h4>' + msg + '</div>';
                break;
            case 'warning':
                _alert = '<div class="alert-dismissible alert alert-' + tipo + '"><button type="button" class="close" data-dismiss="alert" aria-label="Close"><span aria-hidden="true">&times;</span></button><h4><i class="icon fa fa-warning"></i> Atenção!</h4>' + msg + '</div>';
                break;
        }
        if ($("#" + divContainer).hasClass("text-center") != true) {
            $('#' + divContainer).addClass('text-center');
        }
        $('#' + divContainer + '').empty().html(_alert);
    } catch (e) {
        console.log('GERAL - MÉTODO AtivarAlert(tipo: ' + tipo + ', msg: ' + msg + ', divContainer: ' + divContainer + ') - ' + e.message);
    }
}

function DesativarAlert(divContainer) {
    try {
        $('#' + divContainer + '').empty();
    } catch (e) {
        console.log('GERAL - MÉTODO DesativarAlert(divContainer: ' + divContainer + ') - ' + e.message);
    }
}


function AtivarSpin()
{
    $('#divCarregando').css({ display: "block" });
}

function DesativarSpin()
{
    $('#divCarregando').css({ display: "none" });
}


function HabilitarValidacao(campoId, erroMsg) {
    $("#" + campoId).after("<p name='controle_span_errosparceiro'><span id='span_" + campoId + "' style='color:red'>" + erroMsg + "</span></p>")
}

function DesabilitarValidacao(campoId) {
    $("#span_" + campoId).html("");
}

function DesabilitarTodasValidacoes(conteiner) {

    if ((conteiner === undefined) || (conteiner === null))
        conteiner = $(document);

    $("span[data-valmsg-for]", conteiner).html("");
}

function deletar(cod_usuario)
{
    if (confirm("Deseja realmente Excluir este usuário?")) {
        $('#divCarregando').css({ display: "block" });
        $.ajax({
            type: 'POST',
            url: '/usuario/excluir',
            data: {
                codigo: cod_usuario
            },
            dataType: 'JSON',
            cache: false,
            async: false,
            success: function (result) {
                if (result == "OK")
                    location.href = '/Usuario/Index';
                else
                    Alert("Erro ao excluir usuário: " + result);
            }
        });
        
        $('#divCarregando').css({ display: "none" });
    }
}