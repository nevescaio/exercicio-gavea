using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.SS.Util;
using NPOI.XSSF.UserModel;

namespace Exercício_Gávea
{
	public class Portfolio
	{
		public List<Asset> cisneNegroAssets = new List<Asset>();
        public List<Asset> zeroUmAssets = new List<Asset>();
        public List<Asset> allAssets = new List<Asset>();
        public List<double> cisneNegroQuotas = new List<double>();
        public List<double> zeroUmQuotas = new List<double>();
	}
}
