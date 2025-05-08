# Testes do Projeto BankBlock

Este diretório contém os testes unitários do projeto BankBlock, utilizando o framework xUnit para .NET 8.0.

## Estrutura do Projeto

```
Test/
├── Domain/                 # Testes da camada de domínio
│   └── Base/              # Testes das classes base
│       ├── EntityTests.cs
│       └── SecurityUtilsTests.cs
└── Test.csproj           # Arquivo de projeto de testes
```

## Pré-requisitos

- .NET 8.0 SDK ou superior
- Visual Studio 2022, VS Code ou Rider (opcional, para execução via IDE)

## Executando os Testes

### Via Linha de Comando

1. **Executar todos os testes:**
   ```bash
   dotnet test Test/Test.csproj
   ```

2. **Executar com mais detalhes:**
   ```bash
   dotnet test Test/Test.csproj --verbosity normal
   ```

3. **Executar com cobertura de código:**
   ```bash
   dotnet test Test/Test.csproj /p:CollectCoverage=true
   ```

4. **Executar testes específicos:**
   ```bash
   # Executar todos os testes de uma classe específica
   dotnet test Test/Test.csproj --filter "FullyQualifiedName~SecurityUtilsTests"
   
   # Executar um teste específico
   dotnet test Test/Test.csproj --filter "FullyQualifiedName=BankBlock.Tests.Domain.Base.SecurityUtilsTests.HashSHA256_GivenKnownString_ReturnsExpectedHash"
   ```

### Via IDE

#### Visual Studio
1. Abra o Test Explorer (Test > Test Explorer)
2. Clique com o botão direito no teste desejado ou na pasta de testes
3. Selecione "Run" ou "Debug"

#### Rider
1. Abra a janela de testes (View > Tool Windows > Unit Tests)
2. Clique no ícone de play ao lado do teste ou pasta desejada

## Convenções de Nomenclatura

- **Arquivos de Teste:** `[ClasseTestada]Tests.cs`
- **Métodos de Teste:** `[MétodoTestado]_[Cenário]_[ResultadoEsperado]`

Exemplo:
```csharp
public void HashSHA256_GivenKnownString_ReturnsExpectedHash()
```

## Padrões de Teste

Seguimos o padrão AAA (Arrange-Act-Assert) para estruturação dos testes:

```csharp
[Fact]
public void NomeDoTeste()
{
    // Arrange - Preparação do cenário
    var input = "valor de teste";

    // Act - Execução da ação
    var result = ClasseTestada.MetodoTestado(input);

    // Assert - Verificação do resultado
    Assert.Equal(expectedValue, result);
}
```

## Boas Práticas

1. **Isolamento:** Cada teste deve ser independente e não depender de outros testes
2. **Nomes Descritivos:** Use nomes que descrevam claramente o cenário e o resultado esperado
3. **Assertions Claras:** Use assertions específicas e evite múltiplas verificações em um único teste
4. **Setup e Teardown:** Use `[Fact]` para testes simples e `[Theory]` para testes parametrizados
5. **Cobertura:** Mantenha uma boa cobertura de código, focando em casos de borda e cenários de erro

## Manutenção

- Mantenha os testes atualizados quando houver mudanças no código
- Remova testes obsoletos
- Adicione novos testes para novas funcionalidades
- Revise periodicamente a cobertura de código

## Troubleshooting

Se encontrar problemas ao executar os testes:

1. **Erro de Compilação:**
   - Verifique se todas as referências estão corretas
   - Execute `dotnet restore` para restaurar os pacotes

2. **Testes Falhando:**
   - Verifique se as dependências externas estão disponíveis
   - Confirme se os dados de teste estão corretos
   - Verifique se não há problemas de concorrência

3. **Problemas de Performance:**
   - Evite operações pesadas nos testes
   - Use mocks para dependências externas
   - Mantenha os testes focados e rápidos

## Contribuindo

Ao adicionar novos testes:

1. Siga a estrutura de pastas existente
2. Mantenha o padrão de nomenclatura
3. Adicione comentários explicativos quando necessário
4. Certifique-se de que os testes são determinísticos
5. Atualize este README se necessário 