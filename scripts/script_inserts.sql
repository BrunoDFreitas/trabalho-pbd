use pbd;

insert into pessoa (cpf_cnpj, nome, fisico_juridico, tipo_pessoa, ramo, tipo_prestador_serv, tipo_colaborador, setor, pro_labore, data_contratacao, agencia, conta, banco, remuneracao)
values ('12345678901', 'Cliente 1', 'F', 'C', 'Imobiliária', null, null, null, null, null, null, null, null, null); 

insert into
endereco (pessoa_id, uf, cidade, bairro, rua, numero, complemento, descricao)
values (1, 'RS', 'Porto Alegre', 'Centro', 'Júlio de Castilhos', '123', null, 'Prédio Azul');

insert into 
pessoa (cpf_cnpj, nome, fisico_juridico, tipo_pessoa, ramo, tipo_prestador_serv, tipo_colaborador, setor, pro_labore, data_contratacao, agencia, conta, banco, remuneracao)
values ('12345678901234', 'Fornecedor 1', 'J', 'F', null, null, null, null, null, null, null, null, null, null); 

insert into 
pessoa (cpf_cnpj, nome, fisico_juridico, tipo_pessoa, ramo, tipo_prestador_serv, tipo_colaborador, setor, pro_labore, data_contratacao, agencia, conta, banco, remuneracao)
values ('11223344551', 'Terceirizado 1', 'F', 'P', null, 'T', null, null, null, null, null, null, null, null); 

insert into 
pessoa (cpf_cnpj, nome, fisico_juridico, tipo_pessoa, ramo, tipo_prestador_serv, tipo_colaborador, setor, pro_labore, data_contratacao, agencia, conta, banco, remuneracao)
values ('22233344499', 'Funcionario 1', 'F', 'P', null, 'C', 'F', null, null, '2010-01-01', '1234-2', '12345-5', 'Bradesco', 2000.00);

insert into 
pessoa (cpf_cnpj, nome, fisico_juridico, tipo_pessoa, ramo, tipo_prestador_serv, tipo_colaborador, setor, pro_labore, data_contratacao, agencia, conta, banco, remuneracao)
values ('99988877788', 'Sócio 1', 'F', 'P', null, 'C', 'S', null, 5000.00, null, null, null, null, null);

insert into
solicitacao_orcamento (pessoa_id, endereco_id, data_hora, status)
values (1, (select id from endereco where pessoa_id = 1 limit 1), '2017-07-28 13:00:00', 'P');

insert into
orcamento (solicitacao_orcamento_id, data_hora_emissao, valor_total, tempo_estimado, status, garantia, observacao, forma_pagamento)
values ((select id from solicitacao_orcamento where pessoa_id = 1 limit 1), '2017-07-29 09:00:00', 5000, '15 dias', 'P', 'S', null, '50% de entrada. 50% após término.');


