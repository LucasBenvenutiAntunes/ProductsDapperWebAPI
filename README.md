# Desafio

## 1. Problema
Precisamos de uma solução para cadastrar novos produtos. O sistema deve permitir cadastrar produtos e consultar dados dos mesmos. 

## 2. O Desafio

### 2.1. API RESTful para acesso aos produtos e cadastro dos mesmos:
Construir uma API para que seja possível cadastrar novos produtos. Pela API também será possível consultar os produtos.

#### 2.1.1.  GET: /products/{name}
Retorna o produto cadastrado pelo nome
```
{
    "Id": 01,
    "Name": "Produto 01",
    "Price": 100.00,
    "Created": 2020/01/01
}
```

#### 2.1.1  POST: /products
Cadastra um novo produto

#### 2.1.2 DELETE: /products/{name}
Remove um produto

#### 2.1.3 GET /products/ 
Retorna a lista dos produtos em ordem decrescente do último produto cadastrado.

## 3.0 Bônus:
Fazer com que o retorno seja uma lista paginada dos produtos cadastrados

## 4.0 Premissas:
- Versionar o código.
- Maior cobertura de testes possível.
- Código legível.
- Utilizar boas práticas e padrões de projeto.
- Utilizar banco de dados.
