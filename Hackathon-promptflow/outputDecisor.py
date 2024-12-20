from promptflow import tool

# The inputs section will change based on the arguments of the tool function, after you save the code
# Adding type to arguments and return value will help the system show the types properly
# Please update the function name/signature per need

# In Python tool you can do things like calling external services or
# pre/post processing of data, pretty much anything you want


@tool
def echo(input: str, input2: str) -> str:
    # Check which input is not None or empty, and return it
    if input:
        return input
    elif input2:
        return input2
    else:
        return 'Empty response'