$(function () {

    iniciaAcoesDetalheOrcamento();

});

function iniciaAcoesDetalheOrcamento() {
    $('#adicionarservico').unbind('click')
        .bind('click', () => {
            var objServico = $('#novadescricao');
            var descServico = objServico.val();
            objServico.val('');

            var objTable = $('#tableServicos');

            var count = 0;
            var objLinha;
            while ((objLinha = $('#linha' + count)).length > 0) {
                count++;
            }

            var novaLinha =
                '<tr id="linha' + count + '">' +
                    '<td>' +
                        '<input type="text" hidden id="Servicos[' + count + '].Descricao" name="Servicos[' + count + '].Descricao" value="' + descServico + '" />' +
                        descServico +
                    '</td > ' +
                    '<td>' +
                        '<a href= "#" idLinha="linha' + count + '" class="btnRemover" >' +
                            'Remover' +
                        '</a>' +
                    '</td > ' +
                '</tr >';

            var objTBody = $('tbody', objTable);
            objTBody.append(novaLinha);

        });

}