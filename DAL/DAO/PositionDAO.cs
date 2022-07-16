using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.DTO;

namespace DAL.DAO
{
    public class PositionDAO : EmpyeeContext
    {
        public static void AddPosition(POSITION position)
        {
            try
            {
                db.POSITIONs.InsertOnSubmit(position);
                db.SubmitChanges();

            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public static List<PositionDTO> GetPositions()
        {
            try
            {
                var list = (from p in db.POSITIONs
                            join d in db.DEPARTMENTs
                            on p.DepartmentID equals d.ID
                            select new
                            {
                                positionID = p.D,
                                positionName = p.PositionName,
                                departmentName = d.DepartmentName,
                                departmentID = d.ID
                            }).OrderBy(x=>x.positionID).ToList();

                List<PositionDTO> positonList = new List<PositionDTO>();

                foreach(var item in list)
                {
                    PositionDTO dto = new PositionDTO();
                    dto.D = item.positionID;
                    dto.PositionName = item.positionName;
                    dto.DepartmentName = item.departmentName;
                    dto.DepartmentID = item.departmentID;
                    positonList.Add(dto);
                }
                return positonList;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
