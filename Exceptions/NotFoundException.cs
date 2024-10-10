namespace MeuBolsoBackend;

public class NotFoundException(string message = Message.RecursoNaoEncontrado) : Exception(message)
{
}
