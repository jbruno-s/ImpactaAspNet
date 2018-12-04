using System;
using System.IO;
using static System.Configuration.ConfigurationManager;

namespace Oficina.Repositorios
{
    public class RepositorioBase
    {
        protected string obterCaminhoCompleto(string caminho)
        {
            return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, AppSettings[caminho]);
        } 
    }
}