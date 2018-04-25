namespace CodeDomAssistant
{
    using System;

    public class CodeDomAssistantConfig : Config
    {
        private static CodeDomAssistantConfig m_current;

        public static CodeDomAssistantConfig Current
        {
            get
            {
                if (m_current == null)
                {
                    m_current = new CodeDomAssistantConfig();
                }
                return m_current;
            }
            set
            {
                m_current = value;
            }
        }
    }
}

