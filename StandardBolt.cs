using Inventor;
using System;

namespace InvAddIn
{
    internal class StandardBolt : IBolt
    {
        private double Diameter { get; }
        private double Length { get; }
        private double ThreadDepth { get; }
        private double ThreadPitch { get; }

        public StandardBolt(double diameter, double length, double threadDepth, double threadPitch)
        {
            Diameter = diameter;
            Length = length;
            ThreadDepth = threadDepth;
            ThreadPitch = threadPitch;
        }

        public void Create(Application m_inventorApplication)
        {
            try
            {
                PartDocument partDoc = CreatePartDoc(m_inventorApplication);

                // Get the component definition
                PartComponentDefinition compDef = CreatePartComponent(partDoc);

                // Create a sketch
                PlanarSketch sketch = CreatePlanerSketch(compDef, 3);

                double radius = Diameter / 2.0D;

                Point2d centerPoint = CreatePoint2D(m_inventorApplication, 0.0D, 0.0D);
                Point2d circumferencePoint = CreatePoint2D(m_inventorApplication, radius, 0.0D);

                // Create a sketch
                sketch.SketchLines.AddAsPolygon(6, centerPoint, circumferencePoint, false);

                Profile profile = CreateProfileForSolid(sketch);

                // Create an extrude feature for the bolt shape
                ExtrudeFeature extrude = CreateExtrudeDefinition(compDef, profile, PartFeatureOperationEnum.kJoinOperation, radius, PartFeatureExtentDirectionEnum.kNegativeExtentDirection);

                PlanarSketch sketch2 = CreatePlanerSketch(compDef, 3);
                Point2d circleCenter2 = CreatePoint2D(m_inventorApplication, 0.0D, 0.0D);
                sketch2.SketchCircles.AddByCenterRadius(circleCenter2, Diameter / 2.0D);

                Profile profile2 = CreateProfileForSolid(sketch2);

                // Crate an extrude shaper for bolt head with taper angle
                ExtrudeFeature extrude2 = CreateExtrudeDefinition(compDef, profile2, PartFeatureOperationEnum.kIntersectOperation, radius, PartFeatureExtentDirectionEnum.kNegativeExtentDirection, 45.0D);

                PlanarSketch sketch3 = CreatePlanerSketch(compDef, 3);
                Point2d circleCenter3 = CreatePoint2D(m_inventorApplication, 0.0D, 0.0D);
                sketch3.SketchCircles.AddByCenterRadius(circleCenter3, radius / 2.0D);

                Profile profile3 = CreateProfileForSolid(sketch3);

                //Extrude feature for cylindrial part of bolt
                ExtrudeFeature extrude3 = CreateExtrudeDefinition(compDef, profile3, PartFeatureOperationEnum.kJoinOperation, Length, PartFeatureExtentDirectionEnum.kNegativeExtentDirection);

                //Create a thread feature for bolt
                ThreadFeature threadFeature = CreateThreadFeaturs(compDef, extrude3);
                // Update the document
                UpdateAndSavePart(partDoc);

            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(new Exception($"Error creating standard bolt: {ex.Message}"));
            }
        }

        private PartDocument CreatePartDoc(Application inventorApplication)
        {
            return  inventorApplication.Documents.Add(
                    DocumentTypeEnum.kPartDocumentObject,
                    inventorApplication.FileManager.GetTemplateFile(DocumentTypeEnum.kPartDocumentObject)) as PartDocument;
        }

        private PartComponentDefinition CreatePartComponent(PartDocument partDoc)
        {
            return partDoc.ComponentDefinition;
        }

        private PlanarSketch CreatePlanerSketch(PartComponentDefinition compDef, int workPlaneIndex)
        {
            return compDef.Sketches.Add(compDef.WorkPlanes[workPlaneIndex]);
        }

        private Point2d CreatePoint2D(Application inventorApplication, double xCoord, double yCoord)
        {
            return inventorApplication.TransientGeometry.CreatePoint2d(xCoord, yCoord);
        }

        private Profile CreateProfileForSolid(PlanarSketch sketch)
        {
            return sketch.Profiles.AddForSolid();
        }

        private ThreadFeature CreateThreadFeaturs(PartComponentDefinition compDef,ExtrudeFeature extrudeFeature)
        {
            ThreadFeatures tf = compDef.Features.ThreadFeatures;

            ThreadInfo tfInfo = (ThreadInfo)tf.CreateStandardThreadInfo(false, true, "ANSI Unified Screw Threads", "2-20 UN", "2A");
            Face face = CreateFace(extrudeFeature, 1);
            Edge edge = CreateEdge(extrudeFeature, 1, 1);
            return tf.Add(face, edge, tfInfo, false, false, ThreadDepth, 0);
        }

        private Face CreateFace(ExtrudeFeature extrudeFeature, int faceIndex)
        {
            return extrudeFeature.SideFaces[faceIndex];
        }

        private Edge CreateEdge(ExtrudeFeature extrudeFeature, int faceIndex, int edgeIndex)
        {
            return extrudeFeature.EndFaces[faceIndex].Edges[edgeIndex];
        }

        private ExtrudeFeature CreateExtrudeDefinition(PartComponentDefinition compDef, Profile profile, PartFeatureOperationEnum operation, double distance, PartFeatureExtentDirectionEnum
            direction, double taperAngle = 0.0D)
        {
            ExtrudeDefinition extrudeDef = compDef.Features.ExtrudeFeatures.CreateExtrudeDefinition(profile, operation);
            extrudeDef.SetDistanceExtent(distance, direction);
            if (taperAngle > 0.0D) extrudeDef.TaperAngle = Math.PI / 4;
            return compDef.Features.ExtrudeFeatures.Add(extrudeDef);
        }

        private void UpdateAndSavePart(PartDocument partDoc)
        {
            partDoc.Update();
            // Save the document
            // partDoc.SaveAs(@"D:\Mayur_Workspace\FormTestingAddin\BoltIpt\Bolt.ipt", false);
        }
    }
}
