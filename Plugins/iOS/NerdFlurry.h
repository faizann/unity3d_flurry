//
//  NerdFlurry.h
//  Unity-iPhone
//
//  Created by Faizan Naqvi on 1/10/13.
//  Copyright (c) 2013 __MyCompanyName__. All rights reserved.
//

#ifndef Unity_iPhone_NerdFlurry_h
#define Unity_iPhone_NerdFlurry_h



extern "C" {
  void NerdFlurry_startSession(unsigned char* apiKey);
  
  unsigned char* NerdFlurry_getFlurryAgentVersion(); // need BSTR may be?
  void NerdFlurry_setShowErrorInLogEnabled(BOOL bEnabled);
  void NerdFlurry_setDebugLogEnabled(BOOL bEnabled);
  void NerdFlurry_setEventLoggingEnabled(BOOL bEnabled);
  void NerdFlurry_setAge(int age);
  void NerdFlurry_setAppVersion(unsigned char* version);
  
  void NerdFlurry_setGender(unsigned char *gender);
  void NerdFlurry_setSessionContinueSeconds(int seconds);
  void NerdFlurry_setSessionReportsOnCloseEnabled(BOOL bEnabled);
  void NerdFlurry_setSessionReportsOnPauseEnabled(BOOL bEnabled);
  void NerdFlurry_setUserID(unsigned char* userId);
  void NerdFlurry_logEvent(unsigned char* eventId);
  void NerdFlurry_logEventWithParameters(unsigned char* eventId,unsigned char *parameters);
  void NerdFlurry_logEventWithParametersTimed(unsigned char* eventId,unsigned char *parameters);
  void NerdFlurry_logEventTimed(unsigned char* eventId);
  void NerdFlurry_endTimedEvent(unsigned char* eventId); // we accept no parameters
}

#endif
