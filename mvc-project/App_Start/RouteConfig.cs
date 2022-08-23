using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace mvc_project
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");


            routes.MapRoute(
            name: "Home2",
            url: "Home2",
            defaults: new { controller = "Home", action = "Login" }
            );

            routes.MapRoute(
               name: "Home3",
               url: "Home3",
               defaults: new { controller = "Home", action = "Register" }
               );




            routes.MapRoute(
               name: "Deptvm1",
               url: "deptvm1",
               defaults: new { controller = "Deptvm", action = "Index" }
               );

            routes.MapRoute(
             name: "Deptvm2",
             url: "deptvm2",
             defaults: new { controller = "Deptvm", action = "Create" }
             );

            routes.MapRoute(
             name: "Deptwise1",
             url: "Deptwise1",
             defaults: new { controller = "DeptwiseDoctor", action = "Index" }
             );

            routes.MapRoute(
              name: "Deptwise2",
              url: "Deptwise2",
              defaults: new { controller = "DeptwiseDoctor", action = "Create" }
              );

            routes.MapRoute(
             name: "Deptwise3",
             url: "Deptwise3",
             defaults: new { controller = "DeptwiseDoctor", action = "Edit" }
             );


            routes.MapRoute(
             name: "Deptwise4",
             url: "Deptwise4",
             defaults: new { controller = "DeptwiseDoctor", action = "Delete" }
             );


            routes.MapRoute(
             name: "Doctors1",
             url: "Doctors1",
             defaults: new { controller = "Doctors", action = "Index" }
             );


            routes.MapRoute(
            name: "Doctors2",
            url: "Doctors2",
            defaults: new { controller = "Doctors", action = "Create" }
            );


            routes.MapRoute(
            name: "Doctors3",
            url: "Doctors3",
            defaults: new { controller = "Doctors", action = "Edit" }
            );

            routes.MapRoute(
            name: "Doctors4",
            url: "Doctors4",
            defaults: new { controller = "Doctors", action = "Delete" }
            );

            routes.MapRoute(
           name: "DoctorsSalary1",
           url: "DoctorsSalary1",
           defaults: new { controller = "DoctorsSalary", action = "Index" }
           );


            routes.MapRoute(
       name: "DoctorsSalary2",
       url: "DoctorsSalary2",
       defaults: new { controller = "DoctorsSalary", action = "Create" }
       );

            routes.MapRoute(
            name: "DoctorsSalary3",
            url: "DoctorsSalary3",
            defaults: new { controller = "DoctorsSalary", action = "Edit" }
            );

            routes.MapRoute(
            name: "DoctorsSalary4",
            url: "DoctorsSalary4",
            defaults: new { controller = "DoctorsSalary", action = "Delete" }
            );

            routes.MapRoute(
          name: "Maintenence1",
          url: "Maintenence1",
          defaults: new { controller = "Maintenence", action = "Index" }
          );


            routes.MapRoute(
          name: "Maintenence2",
          url: "Maintenence2",
          defaults: new { controller = "Maintenence", action = "Create" }
          );

            routes.MapRoute(
        name: "Maintenence3",
        url: "Maintenence3",
        defaults: new { controller = "Maintenence", action = "Edit" }
        );



            routes.MapRoute(
        name: "Maintenence4",
        url: "Maintenence4",
        defaults: new { controller = "Maintenence", action = "Delete" }
        );


            routes.MapRoute(
       name: "Nurse1",
       url: "Nurse1",
       defaults: new { controller = "Nurse", action = "Index" }
       );

            routes.MapRoute(
   name: "Nurse2",
   url: "Nurse2",
   defaults: new { controller = "Nurse", action = "Create" }
   );

            routes.MapRoute(
       name: "Nurse3",
       url: "Nurse3",
       defaults: new { controller = "Nurse", action = "Edit" }
       );


            routes.MapRoute(
            name: "Nurse4",
                url: "Nurse4",
                defaults: new { controller = "Nurse", action = "Delete" }
            );

            routes.MapRoute(
           name: "Patient1",
               url: "Patient1",
               defaults: new { controller = "Patient", action = "Index" }
           );

            routes.MapRoute(
           name: "Patient2",
               url: "Patient2",
               defaults: new { controller = "Patient", action = "Create" }
           );


            routes.MapRoute(
          name: "Patient3",
              url: "Patient3",
              defaults: new { controller = "Patient", action = "Edit" }

           );

            routes.MapRoute(
        name: "Patient4",
            url: "Patient4",
            defaults: new { controller = "Patient", action = "Delete" }


         );


            routes.MapRoute(
    name: "Admin1",
        url: "Admin1",
        defaults: new { controller = "Admin", action = "Index" }


     );

            routes.MapRoute(
     name: "Admin2",
     url: "Admin2",
     defaults: new { controller = "Admin", action = "Create" }


  );

            routes.MapRoute(
      name: "Admin3",
     url: "Admin3",
   defaults: new { controller = "Admin", action = "Edit" }


    );

            routes.MapRoute(
       name: "Admin4",
       url: "Admin4",
    defaults: new { controller = "Admin", action = "Delete" }


     );

            routes.MapRoute(
     name: "Department1",
     url: "Department1",
  defaults: new { controller = "Department", action = "Index" }


   );


            routes.MapRoute(
      name: "Department2",
      url: "Department2",
      defaults: new { controller = "Department", action = "Create" }


     );

            routes.MapRoute(
     name: "Department3",
     url: "Department3",
    defaults: new { controller = "Department", action = "Edit" }


    );

            routes.MapRoute(
   name: "Department4",
   url: "Department4",
    defaults: new { controller = "Department", action = "Delete" }


);

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
                );

        }
    }
}
