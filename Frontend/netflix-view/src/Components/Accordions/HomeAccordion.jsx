import React from 'react'


const HomeAccordionItem =({title,p1,p2,id,show })=>{
    return(
    <div className="accordion-item">
        <h2 className="accordion-header">
        <button className={`accordion-button ${show==true?"":"collapsed"}`} type="button" data-bs-toggle="collapse" data-bs-target={`#collapse-${id}`} aria-expanded="true" aria-controls={`collapse-${id}`}>
            {title}
        </button>
        </h2>
        <div id={`collapse-${id}`} className={`accordion-collapse collapse ${show ===true ? "show" : ""}`} data-bs-parent={`#accordion`}>
            <div className="accordion-body">
                <p>{p1}</p>
                <p>{p2}</p>
            </div>
        </div>
    </div>
    )
} 

function HomeAccordion({t}) {
  return (
    
    <div  className="accordion" id={`accordion`}>
        <h4>{t("Frequently-Asked-Questions")}</h4>
        <HomeAccordionItem 
                id={1}
                title={t("Accordion-title-1")} 
                p1={t("Accordion-p-1-1")} 
                p2={t("Accordion-p-1-2")}
                show={true}
                />
            <HomeAccordionItem 
                id={2}
                title={t("Accordion-title-2")} 
                p1={t("Accordion-p-2-1")} 
                p2={t("Accordion-p-2-2")}
                show={false}
                />
            <HomeAccordionItem 
                id={3}
                title={t("Accordion-title-3")} 
                p1={t("Accordion-p-3-1")} 
                p2={t("Accordion-p-3-2")}
                show={false}
                />
            <HomeAccordionItem 
                id={4}
                title={t("Accordion-title-4")} 
                p1={t("Accordion-p-4-1")} 
                p2={t("Accordion-p-4-2")}
                show={false}
                />
            <HomeAccordionItem 
                id={5}
                title={t("Accordion-title-5")} 
                p1={t("Accordion-p-5-1")} 
                p2={t("Accordion-p-5-2")}
                show={false}
                />
            <HomeAccordionItem 
                id={6}
                title={t("Accordion-title-6")} 
                p1={t("Accordion-p-6-1")} 
                p2={t("Accordion-p-6-2")}
                show={false}
                />
        </div>
  )
}


export default HomeAccordion