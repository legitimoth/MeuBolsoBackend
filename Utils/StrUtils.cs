namespace MeuBolsoBackend;

public class StrUtils
{
    public static long ToLong(string value)
    {
        if (long.TryParse(value, out long result))
        {
            return result;
        }

        throw new FormatException(Message.ErroParseLong.Bind(value));
    }
}