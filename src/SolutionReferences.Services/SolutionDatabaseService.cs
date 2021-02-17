using DomainModels = SolutionReferences.Domain.Models;
using SolutionReferences.Domain.ServiceInterfaces;
using DataModels = SolutionReferences.Data.Models;
using SolutionReferences.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolutionReferences.Services
{
    public class SolutionDatabaseService : ISolutionDatabaseService
    {
        SolutionReferencesDb _db;

        public SolutionDatabaseService(SolutionReferencesDb db = null)
        {
            _db = db ?? new SolutionReferencesDb();
            
        }
        public void AddSolutionToDatabase(DomainModels.Solution domainSolution)
        {
            var domainReferencedProjectReferences = new List<DomainModels.Reference>();

            var dbSolution = _db.Solutions.Find(domainSolution.Id);
            if (dbSolution == null)
            {
                dbSolution = DbSolutionFromDomainSolution(domainSolution);
                _db.Solutions.Add(dbSolution);
            }
            else 
            { 
                return; 
            }

            // Add unique projects
            var domainProjectIds = domainSolution.Projects.Select(a => a.Id).Distinct();
            var domainProjects = domainSolution.Projects.Where(a => domainProjectIds.Contains(a.Id));
            foreach (var domainProject in domainProjects)
            {
                var dbProject = _db.Projects.Find(domainProject.Id);
                if (dbProject == null)
                {
                    dbProject = DbProjectFromDomainProject(domainProject);
                    _db.Projects.Add(dbProject);
                }
                else
                {
                    //continue;
                }
                //dbSolution.Projects.Add(dbProject);
                dbProject.Solutions.Add(dbSolution);
                // add unique references
                var domainReferenceIds = domainProject.References.Select(a => a.Id).Distinct();
                var domainReferences = domainProject.References.Where(a => domainReferenceIds.Contains(a.Id));
                foreach (var domainReference in domainReferences)
                {
                    var dbReference = _db.References.Find(domainReference.Id);
                    if (dbReference == null)
                    {
                        dbReference = DbReferenceFromDomainReference(domainReference);
                        _db.References.Add(dbReference);
                    }
                    else
                    {
                        //continue;
                    }
                    //dbProject.References.Add(dbReference);
                    dbReference.Projects.Add(dbProject);

                    // defer dealing with project reference
                    if (domainReference.ReferencedProject != null)
                    {
                        domainReferencedProjectReferences.Add(domainReference);
                    }
                }
            }

            // Add Project References
            foreach (var domainReferencedProjectReference in domainReferencedProjectReferences)
            {
                var referencedProject = domainReferencedProjectReference.ReferencedProject;
                var dbReferencedProject = _db.Projects.Find(referencedProject.Id);
                var dbReference = _db.References.Find(domainReferencedProjectReference.Id);
                dbReference.ReferencedProject = dbReferencedProject;
            }

            _db.SaveChanges();
        }




        private DataModels.Solution DbSolutionFromDomainSolution(DomainModels.Solution domainSolution)
        {
            var dataSolution = new DataModels.Solution();
            dataSolution.FilePath = domainSolution.FilePath;
            dataSolution.MinimumVisualStudioVersion = domainSolution.MinimumVisualStudioVersion;
            dataSolution.Name = domainSolution.Name;
            dataSolution.SolutionType = domainSolution.SolutionType;
            dataSolution.SolutionTypeVersion = domainSolution.SolutionTypeVersion;
            dataSolution.VisualStudioFormatVersion = domainSolution.VisualStudioFormatVersion;
            dataSolution.VisualStudioSolutionFileVersion = domainSolution.VisualStudioSolutionFileVersion;
            dataSolution.SolutionId = domainSolution.Id;
            return dataSolution;
        }

        private DataModels.Project DbProjectFromDomainProject(DomainModels.Project domainProject)
        {
            var dataProject = new DataModels.Project();
            dataProject.AssemblyFileVersion = domainProject.AssemblyFileVersion;
            dataProject.AssemblyName = domainProject.AssemblyName;
            dataProject.AssemblyVersion = domainProject.AssemblyVersion;
            dataProject.FilePath = domainProject.FilePath;
            dataProject.Name = domainProject.Name;
            dataProject.PackageId = domainProject.PackageId;
            dataProject.PackageVersion = domainProject.PackageVersion;
            dataProject.ProjectType = domainProject.ProjectType;
            dataProject.RootNamespace = domainProject.RootNamespace;
            dataProject.TargetFramework = domainProject.TargetFramework;
            dataProject.ProjectId = domainProject.Id;
            return dataProject;
        }

        private DataModels.Reference DbReferenceFromDomainReference(DomainModels.Reference domainReference)
        {
            var dataReference = new DataModels.Reference();
            dataReference.FilePath = domainReference.FilePath;
            dataReference.Name = domainReference.Name;
            dataReference.ReferenceType = domainReference.ReferenceType;
            dataReference.Version = domainReference.Version;
            dataReference.ReferenceId = domainReference.Id;
            return dataReference;
        }
    }
}
