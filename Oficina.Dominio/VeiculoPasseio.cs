using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oficina.Dominio
{
    //Todo: OO - herança (:) com a Classe Veiculo.
    public class VeiculoPasseio : Veiculo
    {
        public Carroceria Carroceria { get; set; }

        //Todo: OO - Polimorfismo por sobrescrita.
        public override List<string> Validar()
        {
            var erros = base.ValidarBase();

            if (!Enum.IsDefined(typeof(Carroceria), Carroceria))
            {
                erros.Add($"Não existe essa merda! _|_({Carroceria}).");
            }

            return erros;
        }
    }
}
