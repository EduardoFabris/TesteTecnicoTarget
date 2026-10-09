
const botoesNavegacao = document.querySelectorAll("[data-tela]");
const conteudo = document.querySelector("#conteudo");

const telas = {
    comissao: {
        titulo: "Comissões",
        descricao: "Consulte as comissões calculadas para cada vendedor."
    },
    estoque: {
        titulo: "Movimentação de Estoque",
        descricao: "Registre entradas e saídas de produtos do depósito."
    },
    juros: {
        titulo: "Cálculo de Juros",
        descricao: "Calcule os juros de acordo com o valor e a data de vencimento."
    }
};


async function carregarComissoes() {
    let vendas = [];

    conteudo.innerHTML = `
        <h2>Calcular comissões</h2>
        <p>Adicione as vendas e, ao final, calcule as comissões por vendedor.</p>

        <form id="formVenda">
            <div class="campo-formulario">
                <label for="vendedor">Nome do vendedor</label>
                <input
                    type="text"
                    id="vendedor"
                    placeholder="Ex.: João Silva"
                    required
                >
            </div>

            <div class="campo-formulario">
                <label for="valorVenda">Valor da venda (R$)</label>
                <input
                    type="number"
                    id="valorVenda"
                    min="0.01"
                    step="0.01"
                    placeholder="Ex.: 1200.50"
                    required
                >
            </div>

            <button type="submit" class="botao-primario">
                Adicionar venda
            </button>
        </form>

        <div id="listaVendas"></div>

        <button type="button" id="botaoCalcular" class="botao-primario">
            Calcular comissões
        </button>

        <div id="resultadoComissoes"></div>
    `;

    const formulario = document.querySelector("#formVenda");
    const listaVendas = document.querySelector("#listaVendas");
    const botaoCalcular = document.querySelector("#botaoCalcular");
    const resultado = document.querySelector("#resultadoComissoes");

    const formatarMoeda = (valor) =>
        valor.toLocaleString("pt-BR", {
            style: "currency",
            currency: "BRL"
        });

    function atualizarListaVendas() {
        if (vendas.length === 0) {
            listaVendas.innerHTML = "<p>Nenhuma venda adicionada ainda.</p>";
            return;
        }

        const linhas = vendas.map((venda, indice) => `
            <tr>
                <td>${venda.vendedor}</td>
                <td>${formatarMoeda(venda.valor)}</td>
                <td>
                    <button
                        type="button"
                        class="botao-remover"
                        data-indice="${indice}"
                    >
                        Remover
                    </button>
                </td>
            </tr>
        `).join("");

        listaVendas.innerHTML = `
            <h3>Vendas adicionadas (${vendas.length})</h3>

            <div class="tabela-responsiva">
                <table class="tabela">
                    <thead>
                        <tr>
                            <th>Vendedor</th>
                            <th>Valor da venda</th>
                            <th>Ação</th>
                        </tr>
                    </thead>
                    <tbody>${linhas}</tbody>
                </table>
            </div>
        `;
    }

    formulario.addEventListener("submit", (evento) => {
        evento.preventDefault();

        const vendedor = document.querySelector("#vendedor").value.trim();
        const valor = Number(document.querySelector("#valorVenda").value);

        if (!vendedor || !Number.isFinite(valor) || valor <= 0) {
            return;
        }

        vendas.push({ vendedor, valor });

        formulario.reset();
        atualizarListaVendas();
        resultado.innerHTML = "";
    });

    listaVendas.addEventListener("click", (evento) => {
        const botao = evento.target.closest("[data-indice]");

        if (!botao) {
            return;
        }

        const indice = Number(botao.dataset.indice);
        vendas.splice(indice, 1);

        atualizarListaVendas();
        resultado.innerHTML = "";
    });

    botaoCalcular.addEventListener("click", async () => {
        if (vendas.length === 0) {
            resultado.innerHTML = "<p>Adicione pelo menos uma venda antes de calcular.</p>";
            return;
        }

        resultado.innerHTML = "<p>Calculando comissões...</p>";

        try {
            const resposta = await fetch("http://localhost:5031/api/Comissao", {
                method: "POST",
                headers: {
                    "Content-Type": "application/json"
                },
                body: JSON.stringify({ vendas })
            });

            if (!resposta.ok) {
                throw new Error("Não foi possível calcular as comissões.");
            }

            const comissoes = await resposta.json();

            const linhas = comissoes.map((comissao) => `
                <tr>
                    <td>${comissao.vendedor}</td>
                    <td>${formatarMoeda(comissao.totalVendas)}</td>
                    <td>${formatarMoeda(comissao.totalComissao)}</td>
                </tr>
            `).join("");

            resultado.innerHTML = `
                <h3>Resultado das comissões</h3>

                <div class="tabela-responsiva">
                    <table class="tabela">
                        <thead>
                            <tr>
                                <th>Vendedor</th>
                                <th>Total de vendas</th>
                                <th>Total de comissão</th>
                            </tr>
                        </thead>
                        <tbody>${linhas}</tbody>
                    </table>
                </div>
            `;
        } catch (erro) {
            resultado.innerHTML = `
                <p>Não foi possível calcular as comissões. Verifique se a API está em execução.</p>
            `;

            console.error(erro);
        }
    });

    atualizarListaVendas();
}

botoesNavegacao.forEach((botao) => {
    botao.addEventListener("click", () => {
        const nomeTela = botao.dataset.tela;

        if (nomeTela === "comissao") {
            carregarComissoes();
            return;
        }

        const tela = telas[nomeTela];

        conteudo.innerHTML = `
            <h2>${tela.titulo}</h2>
            <p>${tela.descricao}</p>
        `;
    });
});