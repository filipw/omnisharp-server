namespace OmniSharp.CodeActions
{
    public class ImplementInterfaceResponse
    {
        public ImplementInterfaceResponse(string buffer, bool implementedSuccessfully)
        {
            Buffer = buffer;
            ImplementedSuccessfully = implementedSuccessfully;
        }

        public string Buffer { get; private set; }

        public bool ImplementedSuccessfully { get; private set; }
    }
}