//
//  NerdFlurry.m
//  Unity-iPhone
//
//  Created by Faizan Naqvi on 1/10/13.
//  Copyright (c) 2013 __MyCompanyName__. All rights reserved.
//
#import <stdio.h>
#include "Flurry.h"

void NerdFlurry_startSession(unsigned char* apiKey)
{
  NSString *str = [NSString stringWithUTF8String:apiKey];
  [Flurry startSession:str];
}

unsigned char* NerdFlurry_getFlurryAgentVersion()
{
  NSString *str = [Flurry getFlurryAgentVersion];
  return NULL;
}

void NerdFlurry_setShowErrorInLogEnabled(BOOL bEnabled)
{
  [Flurry setShowErrorInLogEnabled:bEnabled];
}
void NerdFlurry_setDebugLogEnabled(BOOL bEnabled)
{
  [Flurry setDebugLogEnabled:bEnabled];
}

void NerdFlurry_setEventLoggingEnabled(BOOL bEnabled)
{
  [Flurry setEventLoggingEnabled:bEnabled];
}

void NerdFlurry_setAge(int age)
{
  [Flurry setAge:age];
}

void NerdFlurry_setAppVersion(unsigned char* version)
{
  [Flurry setAppVersion:[NSString stringWithUTF8String:version]];
}
void NerdFlurry_setGender(unsigned char *gender)
{
  [Flurry setGender:[NSString stringWithUTF8String:gender]];
}
void NerdFlurry_setSessionContinueSeconds(int seconds)
{
  [Flurry setSessionContinueSeconds:seconds];
}
void NerdFlurry_setSessionReportsOnCloseEnabled(BOOL bEnabled)
{
  [Flurry setSessionReportsOnCloseEnabled:bEnabled];
}

void NerdFlurry_setSessionReportsOnPauseEnabled(BOOL bEnabled)
{
  [Flurry setSessionReportsOnPauseEnabled:bEnabled];
}

void NerdFlurry_setUserID(unsigned char* userId)
{
  [Flurry setUserID:[NSString stringWithUTF8String:userId]];
}

void NerdFlurry_logEvent(unsigned char* eventId)
{
  [Flurry logEvent:[NSString stringWithUTF8String:eventId]];
}

void NerdFlurry_logEventTimed(unsigned char* eventId)
{
  [Flurry logEvent:[NSString stringWithUTF8String:eventId] timed:true];
}

void NerdFlurry_endTimedEvent(unsigned char* eventId) // we accept no parameters
{
  [Flurry endTimedEvent:[NSString stringWithUTF8String:eventId] withParameters:nil];
}