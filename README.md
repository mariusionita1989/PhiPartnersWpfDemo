# PhiPartnersWpfDemo
This is the UI project for the technical assessment.

In order to run this project you will have to download it and make sure you also download the API project ( the backend component ) as well. 
This one can be found here https://github.com/mariusionita1989/HackerNewsApi. You have to make sure the API it is already running, before starting the UI (WPF application).

I have used this approach of having two different components (backend and frontend) because I need it to decouple the UI from the component that is managing the data workflow. 
Also, it is future and feature-proof having the possibility to change the interface at any time if it is needed (we can add a web interface or we can develop mobile apps on Android or iOS).

# How to run the project(s)
1. Download/Open projects with Visual Studio/Visual Studio Code.
2. Unzip the archive and run the projects in the release mode
   in the following order first **HackerNewsApi** and then **PhiPartnersWpfDemo**.
3. Run the WPF project and you will see the output in a window, in case the backend is running,
   otherwise you will  get an error message **_No connection could be made because the target machine actively refused it_**.
4. Make sure you configure the projects properly (check the **App.config** file to point to the correct URL and endpoint)
   It is set by default to point to localhost port 5018, /api/beststories endpoint, but you might need to adapt the settings to your local setup.
5. The backend implements a caching mechanism (it is set to expire after 1 minute), so if you immediately perform a new request you will not have
   to wait because the results are already cached. The same goes for the WPF application (if you press the refresh button immediately the result will be available instantly).
6. Both applications were developed on Windows 10 (64 bits), using Visual Studio 2022, and are targeting .Net 7.
7. The repos are public, so you should not have any issues getting the code.<br/>
   **HackerNewsApi** can be found here https://github.com/mariusionita1989/HackerNewsApi<br/>
   **PhiPartnersWpfDemo** can be found here https://github.com/mariusionita1989/PhiPartnersWpfDemo
