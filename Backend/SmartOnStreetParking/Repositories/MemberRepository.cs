using SmartOnStreetParking.Models;
using SmartOnStreetParking.Web.Utils.Exceptions;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SmartOnStreetParking.Repositories
{
    public class MemberRepository:IMemberRepository
    {
        public void RegisterMember(Member MemberInfo)
        {
            using (var DBContext = new SmartOnStreetParkingDbContext())
            {
                using (DbContextTransaction Transaction = DBContext.Database.BeginTransaction())
                {
                    try
                    {
                        DBContext.Members.Add(MemberInfo);
                        DBContext.SaveChanges();

                        Int64 MemberId = MemberInfo.Id;

                        Transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        Transaction.Rollback();
                        throw ex;
                    }
                }



                
            }

        
        }

        public Member GetById(long Id)
        {
            Member ReturnValue = null;
            using (var DBContext = new SmartOnStreetParkingDbContext())
            {
                ReturnValue = DBContext.Members.Where(v => v.Id == Id).FirstOrDefault();
                if (ReturnValue == null)
                {
                    throw new NotFoundException("Member", Id);
                }
            }

            return ReturnValue;
        }

        public void Edit(Member MemberInfo)
        {
            int MemberToEdit = 0;
            using (var DBContext = new SmartOnStreetParkingDbContext())
            {
                MemberToEdit = DBContext.Members.Count(v => v.Id == MemberInfo.Id);
            }
            if (MemberToEdit > 0)
            {
                using (var DBContext = new SmartOnStreetParkingDbContext())
                {
                    DBContext.Members.Attach(MemberInfo);
                    DBContext.Entry(MemberInfo).State = EntityState.Modified;
                    DBContext.SaveChanges();
                }
            }
        }
    }
}
