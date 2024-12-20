from promptflow import tool
import json


# The inputs section will change based on the arguments of the tool function, after you save the code
# Adding type to arguments and return value will help the system show the types properly
# Please update the function name/signature per need
@tool
def my_python_tool(inPrompt:str, outModerate: str) -> dict:     
    if (outModerate.get("suggested_action") == "Reject"):
        'AUTOCORRECTION'
        if(outModerate.get("action_by_category").get("Hate") == "Reject"):
            return {
                "inPrompt": inPrompt,
                "status": "Reject",
                "category": "Hate"        
            }
        elif(outModerate.get("action_by_category").get("SelfHarm") == "Reject"):
            return {
                "inPrompt": inPrompt,
                "status": "Reject",
                "category": "SelfHarm"        
            }
        elif(outModerate.get("action_by_category").get("Sexual") == "Reject"):
            return {
                "inPrompt": inPrompt,
                "status": "Reject",
                "category": "Sexual"        
            }
        elif(outModerate.get("action_by_category").get("Violence") == "Reject"):
            return {
                "inPrompt": inPrompt,
                "status": "Reject",
                "category": "Violence"        
            }
    else:
        'MODERATE OK'
        return {
            "inPrompt": inPrompt,
            "status": "Acepted",
            "category": ""        
        }
    