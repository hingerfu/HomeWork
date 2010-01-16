//////////////////////////////////////////////////////////////////////
/// ���:��ӭ��
/// ����:Common.cs
/// ����ʱ��009/12/15
/// ���00/12/15
//////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model.Helper;
using Model;
using DAL;

namespace BLL
{
    public class Common
    {
        public object Login(string identityCard, string passWord)
        {
            Teacher teacher = new Teacher();
            Student student = new Student();

            StudentDAL studentDAL = new StudentDAL();
            TeacherDAL teacherDAL = new TeacherDAL();

            try
            {
                student = studentDAL.SelectByProperty(s => s.IdentityCard.Trim() == identityCard.Trim()).FirstOrDefault();
                teacher = teacherDAL.SelectByProperty(t => t.IdentityCard.Trim() == identityCard.Trim()).FirstOrDefault();

                if (student !=null)
                {
                    if (student.PassWord.Trim() == passWord.Trim())
                        return student;
                    else
                        throw new ViladationException(new RuleViolation("�����ȷ."));
                }
                else if (teacher!=null)
                {
                    if (teacher.PassWord.Trim() == passWord.Trim())
                        return teacher;
                    else
                        throw new ViladationException(new RuleViolation("�����ȷ."));
                }
                else
                    throw new ViladationException(new RuleViolation("�������!"));

            }
            catch (AccessDataException ac)
            {
                throw ac;
            }
        }
    }
}
