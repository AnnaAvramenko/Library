using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Mappers
{

        public interface IMapper<Tsource, TDestination>
        {
            Tsource Map(TDestination entity);

            TDestination Map(Tsource entity);

            Tsource Map(TDestination model, Tsource entity);

            List<TDestination> Map(List<Tsource> entity);

            List<Tsource> Map(List<TDestination> entity);
        }

}
