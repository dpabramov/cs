#language = "russian-ru"
#if language == "english":
#    print("Hello")
#    print("Hello2")
#elif language == "russian":
#    print("Hi")
#else: 
#    print("Not equal")
#    print("End")
#print("End")

language = "english"
daytime = "morning1"
if language == "english":
    print("English")
    if daytime == "morning":
        print("Good morning")
    else:
        print("Good evening")
