# WebAPI Pedidos 💻

<p><strong>API de Backend para gerenciamento de pedidos, permitindo aos usuários iniciar pedidos, adicionar ou remover produtos, e fechar pedidos após o preenchimento.</strong></p>

<hr>

<h2>📐 Estrutura do Projeto e Arquitetura</h2>

<p>Essa API foi desenvolvida em ASP.NET Core, com uma estrutura simples de <strong>Controller</strong> e <strong>Model</strong>, seguindo uma abordagem REST para organizar os endpoints de gerenciamento de pedidos e produtos.</p>

<ul>
  <li><strong>Controller</strong>: Recebe as requisições HTTP e executa as operações diretamente.</li>
  <li><strong>Model</strong>: Representa as entidades <code>Pedido</code> e <code>Produto</code> usadas para compor e gerenciar os pedidos.</li>
</ul>

<hr>

<h2>💻 Tecnologias</h2>

<ul>
  <li><strong>ASP.NET Core</strong></li>
  <li><strong>Entity Framework Core</strong></li>
  <li><strong>Entity Framework InMemory</strong> (para persistência de dados em memória)</li>
  <li><strong>Swagger para documentação</strong></li>
</ul>

<hr>

<h2>🚀 Instalação</h2>

<h3>Pré-requisitos</h3>

<p>Certifique-se de ter as seguintes ferramentas instaladas:</p>

<ul>
  <li><strong>.NET 8 SDK</strong></li>
</ul>

<h3>Como configurar o projeto</h3>

<ol>
  <li>Clone o repositório:</li>
  <pre><code>git clone https://github.com/usuario/api-gerenciamento-pedidos.git</code></pre>
  
  <li>Restaure as dependências do projeto:</li>
  <pre><code>dotnet restore</code></pre>

  <li>Inicie o servidor:</li>
  <pre><code>dotnet run</code></pre>
</ol>

<p><em>Observação:</em> Essa API utiliza <strong>Entity Framework InMemory</strong>, o que significa que os dados não são persistidos entre execuções do servidor. Ideal para testes e desenvolvimento.</p>

<hr>

<h2>📍 API Endpoints</h2>

<h3>📌 POST /api/pedidos/iniciar</h3>
<p>Inicia um novo pedido.</p>

<h4>Exemplo de Resposta:</h4>
<pre><code>
{
  "id": 1,
  "produtos": [],
  "isFechado": false
}
</code></pre>

<h3>📌 POST /api/pedidos/{pedidoId}/adicionar</h3>
<p>Adiciona um produto ao pedido.</p>

<h4>Parâmetros:</h4>
<ul>
  <li><code>pedidoId</code>: ID do pedido ao qual o produto será adicionado.</li>
</ul>

<h4>Exemplo de Corpo da Requisição:</h4>
<pre><code>
{
  "id": 1,
  "nome": "Produto Exemplo",
  "preco": 100.00
}
</code></pre>

<h4>Exemplo de Resposta:</h4>
<pre><code>
{
  "id": 1,
  "produtos": [
    {
      "id": 1,
      "nome": "Produto Exemplo",
      "preco": 100.00
    }
  ],
  "isFechado": false
}
</code></pre>

<h3>📌 DELETE /api/pedidos/{pedidoId}/remover/{produtoId}</h3>
<p>Remove um produto de um pedido específico.</p>

<h4>Exemplo de Resposta:</h4>
<pre><code>
{
  "id": 1,
  "produtos": [],
  "isFechado": false
}
</code></pre>

<h3>📌 POST /api/pedidos/{pedidoId}/fechar</h3>
<p>Fecha o pedido se houver produtos adicionados.</p>

<h4>Exemplo de Resposta:</h4>
<pre><code>
{
  "id": 1,
  "produtos": [
    {
      "id": 1,
      "nome": "Produto Exemplo",
      "preco": 100.00
    }
  ],
  "isFechado": true
}
</code></pre>

<h3>📌 GET /api/pedidos</h3>
<p>Lista todos os pedidos, com opção de paginação e filtragem por status.</p>

<ul>
    <li><strong>Parâmetros de consulta:</strong></li>
    <ul>
        <li><code>status</code> (opcional): Permite filtrar os pedidos com o status "aberto" ou "fechado".</li>
        <li><code>page</code> (opcional): Número da página para paginação.</li>
        <li><code>pageSize</code> (opcional): Número de itens por página.</li>
    </ul>
</ul>

<p><strong>Exemplo de requisição:</strong></p>
<pre><code>GET /api/pedidos?status=aberto&page=1&pageSize=10</code></pre>

<p><strong>Exemplo de resposta:</strong></p>
<pre><code>
{
  "paginaAtual": 1,
  "tamanhoPagina": 10,
  "totalPedidos": 50,
  "pedidos": [
    {
      "id": 1,
      "dataCriacao": "2024-11-13T00:00:00Z",
      "produtos": [
        {
          "id": 101,
          "nome": "Produto Exemplo",
          "preco": 100.0
        }
      ],
      "isFechado": false
    }
  ]
}
</code></pre>

<h3>📌 GET /api/pedidos/{pedidoId}</h3>
<p>Retorna as informações de um pedido específico com base no <code>pedidoId</code> informado.</p>

<p><strong>Exemplo de requisição:</strong></p>
<pre><code>GET /api/pedidos/1</code></pre>

<p><strong>Exemplo de resposta:</strong></p>
<pre><code>
{
  "id": 1,
  "dataCriacao": "2024-11-13T00:00:00Z",
  "produtos": [
    {
      "id": 101,
      "nome": "Produto Exemplo",
      "preco": 100.0
    }
  ],
  "isFechado": false
}
</code></pre>

<hr>

<h2>📑 Documentação Swagger</h2>

<p>Para facilitar o uso e teste dos endpoints, uma documentação interativa é gerada automaticamente via Swagger. Acesse a documentação no navegador através da rota abaixo:</p>

<p><code>http://localhost:5272/swagger</code></p>

<hr>
