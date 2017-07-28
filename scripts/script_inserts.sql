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




