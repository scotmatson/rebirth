/*
Necromancer GUI Demo Script
Author: Jason Wentzel
jc_wentzel@ironboundstudios.com

In this script you'll find some handy little functions for some of the 
Custom elements in the skin, these should help you create your own;

AddSpikes (not perfect but works well enough if you�re careful with your window widths)
FancyTop (just an example of using the elements to do a centered header graphic)
WaxSeal (adds the waxseal and ribbon to the right of the window)
DeathBadge (adds the iconFrame, skull, and ribbon elements properly aligned)

*/

var doWindow0 = true;

private var leafOffset;
private var frameOffset;
private var skullOffset;

private var RibbonOffsetX;
private var FrameOffsetX;
private var SkullOffsetX;
private var RibbonOffsetY;
private var FrameOffsetY;
private var SkullOffsetY;

private var WSwaxOffsetX;
private var WSwaxOffsetY;
private var WSribbonOffsetX;
private var WSribbonOffsetY;
	
private var spikeCount;

// This script will only work with the Necromancer skin
var mySkin : GUISkin;

//if you're using the spikes you'll need to find sizes that work well with them these are a few...
var windowRect0 = Rect (118, 18, 750, 510);
private var windowRect1 = Rect (380, 40, 262, 420);
private var windowRect2 = Rect (700, 40, 306, 480);
private var windowRect3 = Rect (0, 40, 350, 500);

private var scrollPosition : Vector2;
private var HroizSliderValue = 0.5;
private var VertSliderValue = 0.5;
private var ToggleBTN = false;

//skin info
private var NecroText ="This started as a question... How flexible is the built in GUI in unity? The answer... pretty damn flexible! At first I wasn�t so sure; it seemed no one ever used it to make a non OS style GUI at least not a publicly available one. So I decided I couldn�t be sure until I tried to develop a full GUI, Long story short Necromancer was the result and is now available to the general public, free for comercial and non-comercial use. I only ask that if you add something Share it.   Credits to Kevin King for the fonts.";


function AddSpikes(winX)
{
	spikeCount = Mathf.Floor(winX - 152)/22;
	GUILayout.BeginHorizontal();
	GUILayout.Label ("", "SpikeLeft");//-------------------------------- custom
	for (i = 0; i < spikeCount; i++)
        {
			GUILayout.Label ("", "SpikeMid");//-------------------------------- custom
        }
	GUILayout.Label ("", "SpikeRight");//-------------------------------- custom
	GUILayout.EndHorizontal();
}

function FancyTop(topX)
{
	leafOffset = (topX/2)-64;
	frameOffset = (topX/2)-27;
	skullOffset = (topX/2)-20;
	GUI.Label(new Rect(leafOffset, 18, 0, 0), "", "GoldLeaf");//-------------------------------- custom	
	GUI.Label(new Rect(frameOffset, 3, 0, 0), "", "IconFrame");//-------------------------------- custom	
	GUI.Label(new Rect(skullOffset, 12, 0, 0), "", "Skull");//-------------------------------- custom	
}

function WaxSeal(x,y)
{
	WSwaxOffsetX = x - 120;
	WSwaxOffsetY = y - 115;
	WSribbonOffsetX = x - 114;
	WSribbonOffsetY = y - 83;
	
	GUI.Label(new Rect(WSribbonOffsetX, WSribbonOffsetY, 0, 0), "", "RibbonBlue");//-------------------------------- custom	
	GUI.Label(new Rect(WSwaxOffsetX, WSwaxOffsetY, 0, 0), "", "WaxSeal");//-------------------------------- custom	
}

function DeathBadge(x,y)
{
	RibbonOffsetX = x;
	FrameOffsetX = x+3;
	SkullOffsetX = x+10;
	RibbonOffsetY = y+22;
	FrameOffsetY = y;
	SkullOffsetY = y+9;
	
	GUI.Label(new Rect(RibbonOffsetX, RibbonOffsetY, 0, 0), "", "RibbonRed");//-------------------------------- custom	
	GUI.Label(new Rect(FrameOffsetX, FrameOffsetY, 0, 0), "", "IconFrame");//-------------------------------- custom	
	GUI.Label(new Rect(SkullOffsetX, SkullOffsetY, 0, 0), "", "Skull");//-------------------------------- custom	
}

function DoMyWindow0 (windowID : int) 
{
	// use the spike function to add the spikes
	// note: were passing the width of the window to the function
		AddSpikes(windowRect0.width);

		GUILayout.BeginVertical();
		GUILayout.Space(8);
		GUILayout.Label("", "Divider");//-------------------------------- custom
        
        
        //GUILayout.Label("Rebirth");
		
		var labelPos = Rect(75,125,600,75);
		GUI.Label(labelPos,"Rebirth",mySkin.FindStyle("Label"));
		
		//GUILayout.Label("Short Label", "ShortLabel");//-------------------------------- custom
		GUILayout.Label("", "Divider");//-------------------------------- custom

		//GUILayout.Button("Play Game");
		var playPos = Rect(175,200,400,75);
		
		GUI.Button(playPos,"Play Game",mySkin.FindStyle("Button"));
		
		
		//This stuff is for the Levels
		var pos = windowRect0;
		pos.y += 300;
		pos.x = 60;
		pos.width = 200;
		pos.height = 50;
		GUI.Button(pos,"Level 1", mySkin.FindStyle("Button"));
		
		pos.x = 280;
		GUI.Button(pos,"Level 2", mySkin.FindStyle("Button"));
		
		pos.x = 500;
		GUI.Button(pos,"Level 3", mySkin.FindStyle("Button"));
		
		//GUILayout.Button("Level 1", "ShortButton");//-------------------------------- custom
		//GUILayout.Button("Level 2", "ShortButton");
		//GUILayout.Button("Level 3", "ShortButton");
		//GUILayout.Label("", "Divider");//-------------------------------- custom
		//ToggleBTN = GUILayout.Toggle(ToggleBTN, "This is a Toggle Button");
		//GUILayout.Label("", "Divider");//-------------------------------- custom
		//GUILayout.Box("This is a textbox\n this can be expanded by using \\n");
		//GUILayout.TextField("This is a textfield\n You cant see this text!!");
      //  GUILayout.TextArea("This is a textArea\n this can be expanded by using \\n");
     
		GUILayout.EndVertical();
		
		// Make the windows be draggable.
		//GUI.DragWindow (Rect (0,0,10000,10000));
}

function OnGUI ()
{
GUI.skin = mySkin;

if (doWindow0)
	windowRect0 = GUI.Window (0, windowRect0, DoMyWindow0, "");
	//now adjust to the group. (0,0) is the topleft corner of the group.
	GUI.BeginGroup (Rect (0,0,50,50));
	// End the group we started above. This is very important to remember!
	GUI.EndGroup ();
	
}