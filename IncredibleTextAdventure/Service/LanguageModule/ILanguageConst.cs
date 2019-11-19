namespace IncredibleTextAdventure.Service.LanguageModule
{
    public interface ILanguageConst
    {
        // Introduction
        string Hello { get; }

        // Errors

        // Room Name
        string OpenSpaceName { get; }
        string DeskOneName { get; }
        string DeskTwoName { get; }
        string DeskThreeName { get; }
        string DeskFourName { get; }
        string ServerRoomName { get; }
        string ComputerRoomName { get; }
        string RestingRoomName { get; }

        // Room Description
        string OpenSpaceFirstDescription { get; }
        string DeskOneFirstDescription { get; }
        string DeskTwoFirstDescription { get; }
        string DeskThreeFirstDescription { get; }
        string DeskFourFirstDescription { get; }
        string ServerRoomFirstDescription { get; }
        string ComputerRoomFirstDescription { get; }
        string RestingRoomFirstDescription { get; }
        string OpenSpaceDescription { get; }
        string DeskOneDescription { get; }
        string DeskTwoDescription { get; }
        string DeskThreeDescription { get; }
        string DeskFourDescription { get; }
        string ServerRoomDescription { get; }
        string ComputerRoomDescription { get; }
        string RestingRoomDescription { get; }

        // Object Name
        string RubiksCubeObjectName{ get; }
        string FlowerInPotObjectName{ get; }
        string ConcertPhotoObjectName{ get; }
        string PileOfStickyNotesObjectName{ get; }
        string DeskFanObjectName{ get; }
        string ChildsDrawingObjectName{ get; }
        string PenHolderObjectName{ get; }
        string CoffeeMachineCoinsObjectName{ get; }
        string TravelBugObjectName{ get; }
        string ServerObjectName{ get; }
        string OpenTerminalObjectName{ get; }
        string EmptyDeskObjectName{ get; }
        string WeirdLookingWorkingStationObjectName{ get; }
        string NotesAboutAUsbKeyObjectName{ get; }
        string ComfyChairsObjectName{ get; }
        string CoffeeMachineObjectName{ get; }

        // Object Description
        string RubiksCubeObjectDesc { get; }
        string FlowerInPotObjectDesc { get; }
        string ConcertPhotoObjectDesc { get; }
        string PileOfStickyNotesObjectDesc { get; }
        string DeskFanObjectDesc { get; }
        string ChildsDrawingObjectDesc { get; }
        string PenHolderObjectDesc { get; }
        string CoffeeMachineCoinsObjectDesc { get; }
        string TravelBugObjectDesc { get; }
        string ServerObjectDesc { get; }
        string OpenTerminalObjectDesc { get; }
        string EmptyDeskObjectDesc { get; }
        string WeirdLookingWorkingStationObjectDesc { get; }
        string NotesAboutAUsbKeyObjectDesc { get; }
        string ComfyChairsObjectDesc { get; }
        string CoffeeMachineObjectDesc { get; }

        // Player
        string EmptyInventory { get; }

        // Directives
    }
}