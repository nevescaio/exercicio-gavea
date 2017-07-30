using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;

namespace Exercício_Gávea
{
    static public class GetData
    {
        public static Portfolio fromExcel(int day)
        {
            // Abir planilha.
            XSSFWorkbook workbook;
            using (FileStream file = new FileStream("dados.xlsx", FileMode.Open, FileAccess.Read))
            {
                workbook = new XSSFWorkbook(file);
            }
            ISheet priceSheet = workbook.GetSheet("Cotações");
            ISheet numberSheet = workbook.GetSheet("Quantidades");
            ISheet portfolioSheet = workbook.GetSheet("Carteira");

            Portfolio portfolio = new Portfolio();
            Asset asset;

            for (int i = 2; i <= 11; i++)
            {
                // Ler os dados da planilha para o dia especificado.
                // Dados do Cisne Negro estao em B3:H12, dados do Zero Um estao em B18:H27
                string name = priceSheet.GetRow(i).GetCell(1).StringCellValue;
                double cisneNegroNumber = numberSheet.GetRow(i).GetCell(day).NumericCellValue;
                double zeroUmNumber = numberSheet.GetRow(i + 15).GetCell(day).NumericCellValue;
                double cisneNegroMoney = portfolioSheet.GetRow(i).GetCell(day).NumericCellValue;
                double zeroUmMoney = portfolioSheet.GetRow(i + 15).GetCell(day).NumericCellValue;

                // Montar listas de ativos de cada fundo
                asset = new Asset();
                asset.name = name;
                asset.number = cisneNegroNumber;
                asset.money = cisneNegroMoney;
                portfolio.cisneNegroAssets.Add(asset);

                asset = new Asset();
                asset.name = name;
                asset.number = zeroUmNumber;
                asset.money = zeroUmMoney;
                portfolio.zeroUmAssets.Add(asset);

                asset = new Asset();
                asset.name = name;
                asset.number = cisneNegroNumber + zeroUmNumber;
                asset.money = cisneNegroMoney + zeroUmMoney;
                portfolio.allAssets.Add(asset);
            }

            // Ler as cotas do primeiro dia ate o dia especificado
            // Cotas do Cisne Negro estao em K15:Q15
            IRow row = portfolioSheet.GetRow(14);
            for (int i = 10; i <= day + 9; i++)
            {
                portfolio.cisneNegroQuotas.Add(row.GetCell(i).NumericCellValue);
            }

            // Cotas do Zero Um estao em B31:H31
            row = portfolioSheet.GetRow(30);
            for (int i = 1; i <= day; i++)
            {
                portfolio.zeroUmQuotas.Add(row.GetCell(i).NumericCellValue);
            }

            return portfolio;
        }
    }
}
